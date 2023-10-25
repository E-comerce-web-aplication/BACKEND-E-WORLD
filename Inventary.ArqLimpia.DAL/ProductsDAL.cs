﻿using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class ProductsDAL : IProduct
    {
        private readonly IMongoCollection<ProductEN> _collection;

        public ProductsDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.Products;
        }

        public async Task Create(ProductEN product)
        {
            await _collection.InsertOneAsync(product);
        }

        public async Task Delete(string productId) 
        {
            var filter = Builders<ProductEN>.Filter.Eq("_id", productId);
            await _collection.DeleteOneAsync(filter);
        }
      
        public async Task<List<ProductEN>> Find(ProductEN product)
        {
            var filter = Builders<ProductEN>.Filter.Empty;
            var result = await _collection.FindAsync(filter);
            return await result.ToListAsync();
        }

        public async Task<ProductEN> FindByName(string product_Name)
        {
            var filter = Builders<ProductEN>.Filter.Eq("Product_Name", product_Name);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<ProductEN> FindOne(string productId)
        {
            var filter = Builders<ProductEN>.Filter.Eq("_id", productId);        
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task Update(ProductEN product)
        {
            var filter = Builders<ProductEN>.Filter.Eq("_id", product._id);
            await _collection.ReplaceOneAsync(filter, product);
        }
    }
}
