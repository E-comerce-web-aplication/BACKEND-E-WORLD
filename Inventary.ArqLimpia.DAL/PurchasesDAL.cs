using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class PurchasesDAL : IPurchases
    {
        private readonly IMongoCollection<PurchaseProductEN> _purchaseCollection;

        public PurchasesDAL(InventoryContextDAL dbContext)
        {
            _purchaseCollection = dbContext.PurchaseProduct;
        }

        public async Task<string> CreatePurchaseTransactionAsync(PurchaseProductEN purchaseTransaction)
        {
            try
            {
                await _purchaseCollection.InsertOneAsync(purchaseTransaction);
                return purchaseTransaction.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar en la base de datos: {ex.Message}");
                throw; 
            }
        }

        public async Task DeletePurchaseTransactionAsync(string Id)
        {
            var filter = Builders<PurchaseProductEN>.Filter.Eq(p => p.Id, Id);
            await _purchaseCollection.DeleteOneAsync(filter);
        }

        public async Task<PurchaseProductEN> GetExistingTransactionAsync(object userId, object companyId)
        {
            var filter = Builders<PurchaseProductEN>.Filter.And(
                Builders<PurchaseProductEN>.Filter.Eq(p => p.UserId.UserId, (int)userId),
                Builders<PurchaseProductEN>.Filter.Eq(p => p.CompanyId, (int)companyId)
            );

            return await _purchaseCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<PurchaseProductEN> GetPurchaseTransactionByIdAsync(string Id)
        {
            var filter = Builders<PurchaseProductEN>.Filter.Eq(p => p.Id, Id);
            return await _purchaseCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<PurchaseProductEN>> GetTransactionsByCompanyAsync(int companyId)
        {
            var filter = Builders<PurchaseProductEN>.Filter.Eq(p => p.CompanyId, companyId);
            return await _purchaseCollection.Find(filter).ToListAsync();
        }

        public async Task<List<PurchaseProductEN>> GetTransactionsByProviderAsync(string providerId)
        {
            var filter = Builders<PurchaseProductEN>.Filter.Eq(p => p.ProviderId, ObjectId.Parse(providerId));
            return await _purchaseCollection.Find(filter).ToListAsync();
        }

        public async Task<List<PurchaseProductEN>> GetTransactionsByUserAsync(int userId)
        {
            var filter = Builders<PurchaseProductEN>.Filter.Eq(p => p.UserId.UserId, userId);
            return await _purchaseCollection.Find(filter).ToListAsync();
        }

        public async Task UpdatePurchaseTransactionAsync(PurchaseProductEN existingTransaction)
        {
            var filter = Builders<PurchaseProductEN>.Filter.Eq(p => p.Id, existingTransaction.Id);
            await _purchaseCollection.ReplaceOneAsync(filter, existingTransaction);
        }
    }
}
