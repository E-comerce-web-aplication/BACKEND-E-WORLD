using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

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
        [BsonElement("Address")]
        public string Address { get; set; }

    }
}
