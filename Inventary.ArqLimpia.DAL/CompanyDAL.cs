using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventary.ArqLimpia.DAL
{
    public class CompanyDAL : ICompany
    {
        private readonly IMongoCollection<Company> _collection;

        public CompanyDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.Company;
        }

        public async Task  Create(Company cCompany)
        {
            await _collection.InsertOneAsync(cCompany);
        }

        public async Task<List<Company>> Find(Company company)
        {
            var filter = Builders<Company>.Filter.Empty;
            var result = await _collection.FindAsync(filter);
            return await result.ToListAsync();
        }

        public async Task<Company> FindByName(string Name)
        {
            var filter = Builders<Company>.Filter.Eq("Name", Name);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<Company> FindOne(string Id)
        {
            var filter = Builders<Company>.Filter.Eq("_id", Id);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }
    }
}
