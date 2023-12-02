using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace inventory.ArqLimpia.EN
{
    public class ReturnEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        [BsonElement("User")]
        [BsonRepresentation(BsonType.Int32)]
        public int UserId { get; set; }

        [BsonElement("Reason")]
        public string Reason { get; set; }

        [BsonElement("Store")]
        [BsonRepresentation(BsonType.Int32)]
        public int StoreId { get; set; }

        [BsonElement("Total")]
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonIgnoreIfDefault]
        public decimal Total { get; set; }

        [BsonElement("Status")]
        [BsonRepresentation(BsonType.String)]
        public ReturnStatus Status { get; set; }
    }

    public enum ReturnStatus
    {
        [BsonRepresentation(BsonType.String)]
        Pending,

        [BsonRepresentation(BsonType.String)]
        Rejected,

        [BsonRepresentation(BsonType.String)]
        Confirmed
    }
}
