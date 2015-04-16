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
            var connectionString = "mongodb://win12itdev:27017";
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
            collName = collName.Replace(@"VOAITDEV\", "z");
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
            TaskContext task = new TaskContext();
            var doc = new Category
            {
                CategoryName = categoryName,
                DateStamp = DateTime.Now
            };                                 

            int count = 0;            

            var query = task.Categories.Find<Category>(x => x.CategoryName == categoryName).Project(x => x.CategoryName).ToListAsync().Result;
            foreach (var item in query)            
                count++;
                        
            if (count == 0)            
                await task.Categories.InsertOneAsync(doc);                                          
            else            
                MessageBox.Show("You cannot have a category with the same name.");                
                        
            return true;
        }

        public async Task<List<string>> FindCategoryNames()
        {
            TaskContext task = new TaskContext();
            List<string> cats = new List<string>();           
            var getCat = task.Categories.Find<Category>(x => x.DateStamp <= DateTime.Now)
                        .Project(x => x.CategoryName).ToListAsync().Result;            
            foreach (var item in getCat)
            {
                cats.Add(item.ToString());
            }
            return cats;
        }
    }
}
