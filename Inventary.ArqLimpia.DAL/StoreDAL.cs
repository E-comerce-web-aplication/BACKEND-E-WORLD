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
    public class StoreDAL : IStore
    {
        private readonly IMongoCollection<StoreEN> _collection;

        public StoreDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.Store;
        }
        public async Task Create(StoreEN sStore)
        {
            await _collection.InsertOneAsync(sStore);
        }

        public async Task<List<StoreEN>> Find(StoreEN store)
        {
            var filter = Builders<StoreEN>.Filter.Empty;
            var result = await _collection.FindAsync(filter);
            return await result.ToListAsync();
        }

        public async Task<StoreEN> FindByName(string Name)
        {
            var filter = Builders<StoreEN>.Filter.Eq("Name", Name);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<StoreEN> FindOne(string Id)
        {
            var filter = Builders<StoreEN>.Filter.Eq("_id", Id);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }
    }
}
