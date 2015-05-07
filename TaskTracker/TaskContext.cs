using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using MongoDB.Shared;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using TaskTracker;
using System.Windows.Forms;
using System.Configuration;

namespace TaskTracker
{
    public class TaskContext
    {

        public const string DATABASE_NAME = "tasks";
        public static string COLLECTION_NAME = "";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static TaskContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
            COLLECTION_NAME = collectionName();
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Category> Categories
        {
            get { return _database.GetCollection<Category>(COLLECTION_NAME); }
        }

        public static string collectionName()
        {
            string collName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            if (collName.Contains("VOAITDEV"))
            {
                collName = collName.Replace(@"VOAITDEV\", "z");
                return collName;
            }
            else if (collName.Contains("\\"))
            {
                collName = collName.Replace(collName.Substring(0, collName.IndexOf("\\") + 1), "");
                return collName;
            }
            else
                return collName;
        }

        public async Task<bool> CreateIndex()
        {
            //TODO: Make this method be called only when the collection is intially created.
            await Categories.Indexes.CreateOneAsync(Builders<Category>.IndexKeys.Ascending(x => x.CategoryName));
            return true;
        }

        #region
        //private MongoClient mongoClient;
        //public MongoClient MongoClient
        //{
        //    get
        //    {
        //        if (mongoClient == null)
        //        {
        //            var connectionString = "mongodb://localhost:27017";
        //            mongoClient = new MongoClient(connectionString);
        //        }

        //        return mongoClient;
        //    }
        //}


        //public IMongoCollection<Category> GetMongoCredentials() 
        //{
        //    var db = MongoClient.GetDatabase("tasks");
        //    string collectionName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        //    collectionName = collectionName.Replace(@"VOAITDEV\", "").Trim();
        //    var col = db.GetCollection<Category>("z"+collectionName);
        //    MessageBox.Show("Hi");
        //    return col;
        //}
        #endregion

        public async Task<bool> InsertCategory(string categoryName)
        {
            // Creates an new instance of task to correct the issue of taskName and taskBody being entered later on.
            var doc = new Category
            {
                CategoryName = categoryName,
                DateStamp = DateTime.Now,
                Task = new List<Task>(),
            };

            // Checks if the category name already exists.
            var query = await FindCategoryNames();
            foreach (var item in query)
            {
                if (item == categoryName)
                {
                    MessageBox.Show("Cannot have duplicate category names.");
                    return true;
                }
            }

            // If the check comes back with nothing then proceed with the insert.                        
            await Categories.InsertOneAsync(doc);
            return true;
        }

        public async Task<bool> DeleteCategory(string categoryName)
        {
            // Matches currently selected category in the drop down and uses its string value to delete the category from mongo collection.
            var query = await Categories.DeleteOneAsync<Category>(x => x.CategoryName == categoryName);
            return true;
        }

        public async Task<List<string>> FindCategoryNames()
        {
            // Grabs only the category names in the collection to become the data source for the drop down list.
            var filter = new BsonDocument();
            var getCat = await Categories.Find<Category>(filter)
                        .Project(x => x.CategoryName)
                        .ToListAsync();
            return getCat.ToList();
        }

        public async Task<bool> InsertNewTask(string taskName, string catName, string index)
        {
            // Creates new task to be inserted later.            
            var doc = new Task
            {
                _id = ObjectId.GenerateNewId(),
                TaskName = taskName,
                DateStamp = DateTime.Now,
                Status = Task._Status.Current.ToString()
            };

            // Check if task name already exists -- Measure to avoid duplicates in collection
            var list = await FindTaskNamesByTab(catName, index);
            if (list.Count() != 0)
            {
                foreach (var item in list)
                {
                    if (item.ToString().ToLower() == taskName.ToLower())
                    {
                        MessageBox.Show("Cannot have duplicate task names.");
                        return true;
                    }
                }
            }

            // Find what category the task should be entered in to then updating it.
            var update = await Categories.UpdateOneAsync(x => x.CategoryName == catName, Builders<Category>.Update.Push(x => x.Task, doc));
            return true;
        }

        public async Task<List<string>> FindTaskNamesByTab(string catName, string index)
        {
            // Grabs all the tasks corresponding to thestatus in the collection.
            string tag = index == "current" ? Task._Status.Current.ToString() : Task._Status.Completed.ToString();
            List<string> tasks = new List<string>();
            var builder = Builders<Category>.Filter;
            var filter = builder.And(builder.Eq(x => x.CategoryName, catName), builder.Eq("tasks.status", tag));
            var find = await Categories.Find<Category>(filter).ToListAsync<Category>();
            if (find.Count > 0)
            {
                foreach (var item in find[0].Task)
                {
                    if (item.Status == tag)
                        tasks.Add(item.TaskName);
                }

                return tasks;
            }
            else
                return new List<string>();            
        }

        public async Task<bool> DeleteTask(string catName, string taskName)
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.And(builder.Eq(x => x.CategoryName, catName), builder.Eq("tasks.task_name", taskName));
            var query = Builders<Category>.Update.Pull("tasks", new BsonDocument() { { "task_name",taskName } });            
            await Categories.FindOneAndUpdateAsync(filter, query);
            return true;
        }

        public async Task<bool> TaskStatus(string catName, string taskName, string tag)
        {
            string query = tag == "Current" ? Task._Status.Completed.ToString():Task._Status.Current.ToString();
            string id = await GetTaskID(catName, taskName);
            var builder = Builders<Category>.Filter;
            var filter = builder.Eq("tasks._id", ObjectId.Parse(id));
            var update = Builders<Category>.Update.Set("tasks.$.status", query);
            await Categories.FindOneAndUpdateAsync(filter, update);
            return true;
        }

        public async Task<string> GetTaskID(string catName, string taskName) 
        {
            string id = "";
            var builder = Builders<Category>.Filter;
            var filter = builder.And(builder.Eq(x => x.CategoryName, catName), builder.Eq("tasks.task_name", taskName));
            var find = await Categories.Find<Category>(filter).ToListAsync<Category>();
            List<Task> tasks = new List<Task>();
            // Cycle through the tasks in the corresponding category to find the matching taskName and then grab the _id. 
            foreach (var item in find[0].Task)
            {                
                if (item.TaskName == taskName)                
                    id = item._id.ToString();                    
                else                
                    continue;                                
            }                
            return id;
        }

        public async Task<Task> GetTasksDetails(string catName, string taskName) 
        {
            var doc = new Task() { };
            var builder = Builders<Category>.Filter;
            var filter = builder.Eq("tasks._id", ObjectId.Parse(await GetTaskID(catName, taskName)));
            var find = await Categories.Find<Category>(filter)                                             
                    .ToListAsync<Category>();
            foreach (var item in find[0].Task)
            {
                if (item.TaskName == taskName)
                {
                    doc._id = item._id;
                    doc.DateStamp = item.DateStamp;
                    doc.TaskBody = item.TaskBody;
                    doc.TaskName = item.TaskName;
                    doc.Status = item.Status;
                }                
            }
            return doc;            
        }

        public async Task<bool> SaveChanges(string taskBody, string taskName, string catName) 
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.Eq("tasks._id", ObjectId.Parse(await GetTaskID(catName, taskName)));
            var update = Builders<Category>.Update.Set("tasks.$.body", taskBody);
            await Categories.FindOneAndUpdateAsync(filter, update);
            return true;
        }
    }
}
