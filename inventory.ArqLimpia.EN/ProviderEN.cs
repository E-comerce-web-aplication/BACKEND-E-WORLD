using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace inventory.ArqLimpia.EN
{
    public class ProviderEN
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRequired]
        [BsonElement("ProviderName")]
        public string ProviderName{ get; set; }

        [BsonRequired]
        [BsonElement("Description")]
        public string Description { get; set; }


        [BsonElement("Contact")]
        public string Contact { get; set; }


        [BsonElement("Email")]
        public string Email { get; set; }


        [BsonElement("Addres")]
        public string Address { get; set; }


        [BsonElement("City")]
        public string City { get; set; }


        [BsonElement("PostalCode")]
        public string PostalCode { get; set; }


        





    }
}
