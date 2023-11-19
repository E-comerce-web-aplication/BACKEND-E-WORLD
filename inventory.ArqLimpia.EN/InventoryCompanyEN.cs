using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class InventoryCompanyEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("CompanyId")]
        public int CompanyId { get; set; }

        [BsonElement("Company")]
        public string Company { get; set; }

        [BsonElement("ProductId")]
        public ObjectId ProductId { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }
}
