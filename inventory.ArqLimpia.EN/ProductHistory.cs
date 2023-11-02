using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic; // Agregar este using para List<string>

namespace inventory.ArqLimpia.EN
{
    public class ProductHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRequired]
        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonRequired]
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonRequired]
        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonRequired]
        [BsonElement("Stock")]
        public int Stock { get; set; }

        [BsonRequired]
        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonRequired]
        [BsonElement("ExtraDescriptions")]
        public string ExtraDescriptions { get; set; }

        [BsonRequired]
        [BsonElement("ShippingConditions")]
        public string ShippingConditions { get; set; }

        [BsonRequired]
        [BsonElement("Tags")]
        public List<string> Tags { get; set; }
    }
}
