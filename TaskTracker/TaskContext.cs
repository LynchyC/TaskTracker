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
                Task = new List<Task>()
            };                                 

            int count = 0;            
            // Checks if the category name already exists.
            var query = Categories.Find<Category>(x => x.CategoryName == categoryName).Project(x => x.CategoryName).ToListAsync().Result;
            foreach (var item in query)            
                count++;
             // If the check comes back with nothing then proceed with the insert.                        
            if (count == 0)            
                await Categories.InsertOneAsync(doc);                                          
            else            
                MessageBox.Show("You cannot have a category with the same name.");                
                        
            return true;
        }

        public async Task<bool> DeleteCategory(string categoryName) 
        {            
            var query = await Categories.DeleteOneAsync<Category>(x => x.CategoryName == categoryName);
            return true;
        }

        public async Task<List<string>> FindCategoryNames()
        {
            // Grabs only the category names in the collection to become the data source for the drop down list.
            var filter = new BsonDocument();
            List<string> cats = new List<string>();           
            var getCat = Categories.Find<Category>(filter)
                        .Project(x => x.CategoryName).ToListAsync().Result;            
            foreach (var item in getCat)
            {
                cats.Add(item.ToString());
            }
            return cats;
        }

        public async Task<bool> InsertNewTask(string taskName,string catName)
        {
            // For now just adding the task name into the catergories             
            var doc = new Task
            {
                TaskName = taskName
            };
            
            // Find what category the task should be entered in to then updating it.
            var update = await Categories.UpdateOneAsync(Builders<Category>.Filter.Eq("name", catName), Builders<Category>.Update.Push(x => x.Task, doc));
            return true;
        }

        public async Task<List<string>> FindTaskNames(string catName) 
        {
            // Grabs all the task names in the passed category
            var taskNames = await Categories.Find(x => x.CategoryName == catName)
                            .Project(x => x.Task.Select(y => y.TaskName))
                            .ToListAsync();
            return taskNames[0].ToList();
        }
    }
}
