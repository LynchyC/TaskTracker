﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskTracker
{
    public class Task
    {
        [BsonElement("name")]
        public string TaskName { get; set; }

        [BsonElement("body")]
        public string TaskBody { get; set; }

        [BsonDateTimeOptions]
        [BsonElement("dateCreated")]
        public DateTime DateStamp { get; set; }
    }
}
