using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace inventory.ArqLimpia.EN
{
    public class InventoryCompanyEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("CompanyId")]
        public int CompanyId { get; set; }

        [BsonElement("ProductId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("ProductInfo")]
        public List<ProductEN> ProductInfo { get; set; }
    }
    
}
