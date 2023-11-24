using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class ProviderDAL : IProvider
    {
        private readonly IMongoCollection<ProviderEN> _provider;

        public ProviderDAL(InventoryContextDAL dbContext)
        {
            _provider = dbContext.Provider;
        }
        public async Task Create(ProviderEN pProvider)
        {
            await _provider.InsertOneAsync(pProvider);
        }

        public async Task Delete(string providerId)
        {
            var filter = Builders<ProviderEN>.Filter.Eq("_id", providerId);
            await _provider.DeleteOneAsync(filter);
        }

        public async Task<List<ProviderEN>> Find(ProviderEN provider)
        {
            var filter = Builders<ProviderEN>.Filter.Empty;
            var result = await _provider.FindAsync(filter);
            return await result.ToListAsync();
        }

        public async Task<ProviderEN> FindByName(string providerName)
        {
            var filter = Builders<ProviderEN>.Filter.Eq("ProviderName", providerName);
            return await _provider.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ProviderEN> FindOne(string providerId)
        {
            var filter = Builders<ProviderEN>.Filter.Eq("_id", providerId);
            return await _provider.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(ProviderEN pProvider)
        {
            var filter = Builders<ProviderEN>.Filter.Eq("_id", pProvider._id);
            var update = Builders<ProviderEN>.Update
                .Set("ProviderName", pProvider.ProviderName)
                .Set("Description", pProvider.Description)
                .Set("Contact", pProvider.Contact)
                .Set("Email", pProvider.Email)
                .Set("Address", pProvider.Address)
                .Set("City", pProvider.City)
                .Set("PostalCode", pProvider.PostalCode);

            await _provider.UpdateOneAsync(filter, update);
        }
    }
}
