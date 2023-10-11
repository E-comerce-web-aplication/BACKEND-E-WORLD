using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory.ArqLimpia.EN
{
    public class OrdersEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("OrderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("StoreId")]
        public string StoreId { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [BsonElement("Total")]
        public double Total { get; set; }
    }
}
