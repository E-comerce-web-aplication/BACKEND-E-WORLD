using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace inventory.ArqLimpia.EN
{
    public class ProductReturnEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("ProductId")]
        public string ProductId { get; set; }

        [BsonElement("Returns")]
        public string Returns { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

    }
}
