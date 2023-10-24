using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory.ArqLimpia.EN
{
    public class OrdersProductEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProductId")]
        public string ProductId { get; set; }

        [BsonElement("OrderId")]
        public string OrderId { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

    }
}
