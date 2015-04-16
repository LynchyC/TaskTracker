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

        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        //public string _id { get; set; }

        [BsonElement("name")]
        public string CategoryName { get; set; }

        [BsonDateTimeOptions]
        [BsonElement("dateCreated")]
        public DateTime DateStamp { get; set; }
       
        [BsonElement("tasks")]        
        public List<TaskTracker.Task> Task { get; set; }
    }
}
