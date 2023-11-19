using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class InventoryStoreEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("StoreId")]
        public int StoreId { get; set; }

        [BsonElement("ProductId")]
        public ObjectId ProductId { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }
}
