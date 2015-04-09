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
        public Category(string category,DateTime date)
        {
            CategoryName = category;
            DateStamp = date;            
        }

        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }

        [BsonElement]
        public string CategoryName { get; set; }

        [BsonDateTimeOptions]
        public DateTime DateStamp { get; set; }
    }
}
