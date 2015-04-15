using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using TaskTracker;

namespace TaskTracker
{
    public class TaskContext
    {
        private MongoClient mongoClient;
        public MongoClient MongoClient
        {
            get
            {
                if (mongoClient == null)
                {
                    var connectionString = "mongodb://localhost:27017";
                    mongoClient = new MongoClient(connectionString);
                }

                return mongoClient;
            }
        }

        public IMongoCollection<Category> GetMongoCredentials() 
        {
            var db = mongoClient.GetDatabase("Tasks");
            string collectionName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            collectionName = collectionName.Replace(@"VOAITDEV\", "");
            var col = db.GetCollection<Category>(collectionName);
            return col;
        }

        public async Task InsertCategory(string categoryName)
        {
            
            var col = GetMongoCredentials();
            var doc = new Category
            {
                CategoryName = categoryName,
                DateStamp = DateTime.Now
            };

            await col.InsertOneAsync(doc);

        }

    }
}
