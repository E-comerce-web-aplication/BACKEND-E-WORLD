using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace inventory.ArqLimpia.EN
{
    public class ProductEN
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }

    [BsonRequired]
    [BsonElement("product_name")]
    public string Product_Name { get; set; }

    [BsonRequired]
    [BsonElement("description")]
    public string Description { get; set; }

    [BsonRequired]
    [BsonElement("stock")]
    public int Stock { get; set; }

    [BsonRequired]
    [BsonElement("price")]
    [BsonRepresentation(BsonType.Double)]
    public double Price { get; set; }

    [BsonElement("images")]
    public List<string> Images { get; set; }

    [BsonElement("tags")]
    public List<string> Tags { get; set; }

    [BsonElement("category")]
    public string Category { get; set; }

    [BsonRequired]
    [BsonElement("company_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CompanyId { get; set; }
    }

    
}

