using inventory.ArqLimpia.EN;
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
        // Agrega otras colecciones si es necesario
    }
}

