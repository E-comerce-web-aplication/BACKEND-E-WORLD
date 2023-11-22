using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class ProductsDAL : IProduct
    {
        private readonly IMongoCollection<ProductEN> _collection;
        private readonly IMongoCollection<ProductHistory> _productHistoryCollection;

        public ProductsDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.Products;
            _productHistoryCollection = dbContext.ProductHistory;
        }

        public async Task Create(ProductEN product)
        {
            ProductHistory productHistory = new ProductHistory
            {
                _id = product._id,
                ProductName = product.ProductName,
                Title = product.Title,
                Description = product.Description,
                Images = product.Images,
                Stock = product.Stock,
                Price = product.Price,
                CompanyId = product.CompanyId,
                SendConditions = product.SendConditions,
                Tags = product.Tags
            };

            await _collection.InsertOneAsync(product);
            await _productHistoryCollection.InsertOneAsync(productHistory);
        }
        private async Task CreateInProductHistory(ProductHistory product)
        {
            await _productHistoryCollection.InsertOneAsync(product);
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

        public async Task Update(ProductEN updatedProduct)
        {
           
            var filter = Builders<ProductEN>.Filter.Eq("_id", updatedProduct._id);
            var originalProduct = await _collection.Find(filter).FirstOrDefaultAsync();

            if (originalProduct != null)
            {
               
                ProductHistory productHistory = new ProductHistory
                {
                    ProductName = originalProduct.ProductName,
                    Title = originalProduct.Title,
                    Description = originalProduct.Description,
                    Images = originalProduct.Images,
                    Stock = originalProduct.Stock,
                    Price = originalProduct.Price,
                    CompanyId = originalProduct.CompanyId,
                    SendConditions = originalProduct.SendConditions,
                    Tags = originalProduct.Tags,
                    Timestamp = DateTime.UtcNow,

                };

              
                await _productHistoryCollection.InsertOneAsync(productHistory);

               
                await _collection.ReplaceOneAsync(p => p._id == updatedProduct._id, updatedProduct);
            }
        }


    }
}
