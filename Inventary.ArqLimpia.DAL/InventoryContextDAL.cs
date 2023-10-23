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
        public IMongoCollection<Company> Company => _database.GetCollection<Company>("Company");
        public IMongoCollection<StoreEN> Store => _database.GetCollection<StoreEN>("Store");
        public IMongoCollection<OrdersProductEN> OrderProducts => _database.GetCollection<OrdersProductEN>("OrdersProducts");
    }
}

