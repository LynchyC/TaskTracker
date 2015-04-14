using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TaskTracker
{
    public class TaskContext
    {
        public static void ConnectToDB()
        {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase("Tasks");
            string collectionName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            collectionName = collectionName.Replace(@"VOAITDEV\", "");
            var col = db.GetCollection<Category>(collectionName);
        }

        static async Task InsertCategory() 
        {
            
        }
                   
    }
}
