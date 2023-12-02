using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class InventoryContextDAL
    {
        private readonly IMongoDatabase _database;

        public InventoryContextDAL(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Agrega propiedades para acceder a las colecciones aquí
        public IMongoCollection<ProductEN> Products => _database.GetCollection<ProductEN>("Products");
        public IMongoCollection<OrdersEN> Orders => _database.GetCollection<OrdersEN>("Orders");
        public IMongoCollection<ProductRegisterEN> ProductRegister => _database.GetCollection<ProductRegisterEN>("ProductRegister");
        public IMongoCollection<ProductHistory> ProductHistory => _database.GetCollection<ProductHistory>("ProductHistory");
        public IMongoCollection<OrdersProductEN> OrderProduct => _database.GetCollection<OrdersProductEN>("OrderProduct");
        public IMongoCollection<InventoryStoreEN> InventoryStore => _database.GetCollection<InventoryStoreEN>("InventoryStore");
        public IMongoCollection<InventoryCompanyEN> InventoryCompany => _database.GetCollection<InventoryCompanyEN>("InventoryCompany");
        public IMongoCollection<PurchaseProduct> PurchaseProduct => _database.GetCollection<PurchaseProduct>("PurchaseProduct");
        public IMongoCollection<Purchase> Purchase => _database.GetCollection<Purchase>("Purchase");
        public IMongoCollection<ProviderEN> Provider => _database.GetCollection<ProviderEN>("Provider");
        public IMongoCollection<ReturnEN> Return => _database.GetCollection<ReturnEN>("Returns");
        public IMongoCollection<ProductReturnEN> ProductReturn => _database.GetCollection<ProductReturnEN>("ProductReturn");
    }
}

