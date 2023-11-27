
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace inventory.ArqLimpia.EN
{
    public class PurchaseProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRequired]
        [BsonElement("PurchaseId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PurchaseId { get; set; }

        [BsonRequired]
        [BsonElement("ProductId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonRequired]
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
        
    }
}
