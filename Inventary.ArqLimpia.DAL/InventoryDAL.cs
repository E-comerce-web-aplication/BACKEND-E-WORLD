using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Inventary.ArqLimpia.DAL
{
    public class InventoryDAL : IInventory
    {
        private readonly IMongoCollection<InventoryStoreEN> _inventoryStoreCollection;
        private readonly IMongoCollection<InventoryCompanyEN> _inventoryCompanyCollection;

        public InventoryDAL(InventoryContextDAL dbContext)
        {
            _inventoryStoreCollection = dbContext.InventoryStore;
            _inventoryCompanyCollection = dbContext.InventoryCompany;
        }
        public async Task<List<InventoryCompanyEN>> FindAllCompanies(int companyId)
        {
            var matchStage = new BsonDocument("$match", new BsonDocument("CompanyId", companyId));

            var lookupStage = new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "Products" },
                { "localField", "ProductId" },
                { "foreignField", "_id" },
                { "as", "ProductInfo" }
            });

            var pipeline = new[] { matchStage, lookupStage };

            var aggregation = await _inventoryCompanyCollection.Aggregate<InventoryCompanyEN>(pipeline).ToListAsync();
            return aggregation;
        }

        public async Task<List<InventoryStoreEN>> FindAllStores(int storeId)
        {
            var filter = Builders<InventoryStoreEN>.Filter.Eq("StoreId", storeId);
            return _inventoryStoreCollection.Find(filter).ToList();
        }
    }
}
