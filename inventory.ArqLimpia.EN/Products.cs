using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace inventory.ArqLimpia.EN
{
    public class ProductEN
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

        [BsonElement("Images")]
        public List<string> Images { get; set; }

        [BsonRequired]
        [BsonElement("Stock")]
        public int Stock { get; set; }

        [BsonRequired]
        [BsonElement("Price")]
        [BsonRepresentation(BsonType.Double)]
        public double Price { get; set; }

        [BsonRequired]
        [BsonElement("CompanyId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }

        [BsonElement("SendConditions")]
        public string SendConditions { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; }
    }
}
