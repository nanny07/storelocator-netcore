using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreLocator.Models
{
    public class Store
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Rating { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
