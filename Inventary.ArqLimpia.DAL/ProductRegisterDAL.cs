using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;
using System.ComponentModel.Design;

namespace Inventary.ArqLimpia.DAL
{
    public class ProductRegisterDAL : IProductRegister
    {
        private readonly IMongoCollection<ProductRegisterEN> _collection;

        public ProductRegisterDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.ProductRegister;
        }

        public async Task<List<ProductRegisterEN>> FindAll(string CompanyId, string UserName)
        {
            FilterDefinition<ProductRegisterEN> filter = Builders<ProductRegisterEN>.Filter.Empty;

            if (!string.IsNullOrEmpty(CompanyId))
            {
                filter = Builders<ProductRegisterEN>.Filter.Eq("CompanyId", CompanyId);
            }

            if (!string.IsNullOrEmpty(UserName))
            {
                var userFilter = Builders<ProductRegisterEN>.Filter.Eq("User.name", UserName);
                filter = filter & userFilter;
            }

            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }
    }
}
