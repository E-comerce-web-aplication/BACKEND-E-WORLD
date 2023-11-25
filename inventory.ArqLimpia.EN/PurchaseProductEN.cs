
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace inventory.ArqLimpia.EN
{
    public class PurchaseProductEN
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonRequired]
        [BsonElement("User")]
        public User UserId { get; set; }

        [BsonRequired]
        [BsonElement("Products")]
        public List<Product> Products { get; set; }

        [BsonRequired]
        [BsonElement("Total")]
        public double Total { get; set; }

        [BsonRequired]
        [BsonElement("purchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [BsonRequired]
        [BsonElement("Company")]
        public int CompanyId { get; set; }

        [BsonRequired]
        [BsonElement("ProviderId")]
        public ObjectId ProviderId { get; set; }

        public class User
        {
            [BsonRequired]
            [BsonElement("UserId")]
            public int UserId { get; set; }
        }

        public class Product
        {
            [BsonRequired]
            [BsonElement("IdProduct")]
            public string IdProduct { get; set; }

            [BsonRequired]
            [BsonElement("Price")]
            public double Price { get; set; }

            [BsonRequired]
            [BsonElement("Amount")]
            public int Amount { get; set; }
        }

        public class Company
        {
            [BsonRequired]
            [BsonElement("CompanyId")]
            public int CompanyId { get; set; }
        }
    }
}
