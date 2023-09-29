using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace inventory.ArqLimpia.EN
{
    public class ProductEN
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonRequired]
    [BsonElement("ProductName")]
    public string ProductName { get; set; }

    [BsonRequired]
    [BsonElement("Description")]
    public string Description { get; set; }

    [BsonRequired]
    [BsonElement("Stock")]
    public int Stock { get; set; }

    [BsonRequired]
    [BsonElement("Price")]
    [BsonRepresentation(BsonType.Double)]
    public double Price { get; set; }

    [BsonElement("Images")]
    public List<string> Images { get; set; }

    [BsonElement("tags")]
    public List<string> Tags { get; set; }

    [BsonRequired]
    [BsonElement("companyCategoryId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CompanyCategoryId { get; set; }

    [BsonRequired]
    [BsonElement("companyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CompanyId { get; set; }
    }

    
}

