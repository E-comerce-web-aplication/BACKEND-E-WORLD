﻿using inventory.ArqLimpia.EN;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ProductRegisterEN
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("Date")]
    public DateTime Date { get; set; }

    [BsonElement("User")]
    public User User { get; set; }

    [BsonElement("Product_info")]
    public ObjectId Product_info { get; set; }

    [BsonElement("Company_name")]
    public string Company_name { get; set; }

    [BsonElement("Type")]
    public ProductType Type { get; set; }

    [BsonElement("Changes")]
    public BsonDocument Changes { get; set; }

    [BsonElement("CompanyId")]
    public int CompanyId { get; set; }
}

public class User
{
    public string name { get; set; }
    public string role { get; set; }

    public static implicit operator User(Purchase v)
    {
        throw new NotImplementedException();
    }
}

public enum ProductType
{
    NewProduct,
    ProductDeletion,
    ProductUpdate
}
