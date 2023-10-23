using Inventory.ArqLimpia.EN;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class StoreEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonRequired]
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonRequired]
        [BsonElement("PostalCode")]
        public string PostalCode { get; set; }

        [BsonRequired]
        [BsonElement("Department")]
        public string Department { get; set; }

        [BsonRequired]
        [BsonElement("City")]
        public string City { get; set; }

        [BsonRequired]
        [BsonElement("Address")]
        public string Address { get; set; }
    }
}