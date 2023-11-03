using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class ProductHistoryDAL : IProducHistory
    {
        private readonly IMongoCollection<ProductHistory> _collection;

        public ProductHistoryDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.ProductHistory;
        }

        public async Task<List<ProductHistory>> FindAll(string CompanyId)
        {
            var filter = Builders<ProductHistory>.Filter.Eq("CompanyId", CompanyId);
            var result = await _collection.FindAsync(filter);
            return await result.ToListAsync();
        }
    }
}
