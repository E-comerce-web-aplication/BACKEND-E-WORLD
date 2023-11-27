using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace inventory.ArqLimpia.EN
{
    public class Purchase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        
        [BsonRequired]
        [BsonElement("UserId")]
        public int UserId { get; set; }

        [BsonRequired]
        [BsonElement("Total")]
        public double Total { get; set; }

        [BsonRequired]
        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonRequired]
        [BsonElement("CompanyId")]
        public int CompanyId { get; set; }

        [BsonRequired]
        [BsonElement("ProviderId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProviderId { get; set; }

    }
}