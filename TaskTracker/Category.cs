using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskTracker
{
    public class Category
    {

        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }

        [BsonElement("name")]
        public string CategoryName { get; set; }

        [BsonDateTimeOptions]
        [BsonElement("dateCreated")]
        public DateTime DateStamp { get; set; }
       
        [BsonElement("current_tasks")]        
        public List<TaskTracker.CurrentTask> CurrentTask { get; set; }

        [BsonElement("completed_tasks")]
        public List<TaskTracker.CompletedTask> CompletedTask { get; set; }


    }
}
