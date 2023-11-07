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

        public async Task<List<ProductRegisterEN>> FindAllByCompanyId(string companyId)
        {
            var filter = Builders<ProductRegisterEN>.Filter.Eq("CompanyId", companyId);
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<List<ProductRegisterEN>> FindAllByName(string name)
        {
            var filter = Builders<ProductRegisterEN>.Filter.Eq("User.name", name);
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }
    }    
}