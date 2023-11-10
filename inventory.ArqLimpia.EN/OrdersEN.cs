using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory.ArqLimpia.EN
{
    public class OrdersEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderDate { get; set; }

        [BsonElement("User")]
        [BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }

        [BsonElement("Store")]
        [BsonRepresentation(BsonType.Int32)]
        public int StoreId { get; set; }

        [BsonElement("Total")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Total { get; set; }
    }
}





