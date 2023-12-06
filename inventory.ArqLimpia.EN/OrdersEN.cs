using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory.ArqLimpia.EN
{
    public class OrdersEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderDate { get; set; }

        [BsonElement("User")]
        [BsonRepresentation(BsonType.Int32)]
        public int UserId { get; set; }

        [BsonElement("Store")]
        [BsonRepresentation(BsonType.Int32)]
        public int StoreId { get; set; }

        [BsonElement("Total")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Total { get; set; }

        [BsonElement("Status")]
        [BsonRepresentation(BsonType.String)]
        public OrderStatus Status { get; set; }

        [BsonElement("ProductInfo")]
        public List<OrdersEN> ProductInfo { get; set; }
    }

    public enum OrderStatus
    {
        [BsonRepresentation(BsonType.String)]
        Pending,

        [BsonRepresentation(BsonType.String)]
        Rejected,

        [BsonRepresentation(BsonType.String)]
        Confirmed
    }
}
