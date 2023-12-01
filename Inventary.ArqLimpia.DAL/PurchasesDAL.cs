using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class PurchasesDAL : IPurchases
    {
        private readonly IMongoCollection<Purchase> _purchaseCollection;
        private readonly IMongoCollection<PurchaseProduct> _purcharseProductCollection;
        private readonly IMongoCollection<InventoryCompanyEN> _inventoryCollection;

        public PurchasesDAL(InventoryContextDAL dbContext)
        {
            _purchaseCollection = dbContext.Purchase;
            _purcharseProductCollection = dbContext.PurchaseProduct;
            _inventoryCollection = dbContext.InventoryCompany;
        }

        public async Task<string> CreatePurchaseTransactionAsync(PurcharseProductsDTOs purchase)
        {
            try
            {
                Purchase purcharse = new Purchase
                {
                    Total = purchase.Total,
                    UserId = purchase.UserId,
                    CompanyId = purchase.CompanyId,
                    ProviderId = purchase.ProviderId,
                    Date = DateTime.Now
                };

                // Insertar en la colección Purchase
                await _purchaseCollection.InsertOneAsync(purcharse);

                var purchaseProducts = new List<PurchaseProduct>();
                var productInventoryUpdates = new List<UpdateOneModel<InventoryCompanyEN>>();

                foreach (var purchaseInput in purchase.Products)
                {
                    PurchaseProduct purchaseProduct = new PurchaseProduct
                    {
                        ProductId = purchaseInput.ProductId,
                        PurchaseId = purcharse._id,
                        Quantity = purchaseInput.Quantity,
                    };
                    purchaseProducts.Add(purchaseProduct);

                    // Crear el filtro para el producto en la colección InventoryCompany
                    var filter = Builders<InventoryCompanyEN>.Filter.And(
                        Builders<InventoryCompanyEN>.Filter.Eq(ic => ic.ProductId, purchaseInput.ProductId),
                        Builders<InventoryCompanyEN>.Filter.Eq(ic => ic.CompanyId, purcharse.CompanyId)
                    );

                    // Crear la actualización para sumar la cantidad al producto existente o insertar uno nuevo
                    var update = Builders<InventoryCompanyEN>.Update.Inc(ic => ic.Quantity, purchaseInput.Quantity);

                    // Agregar la actualización al lote
                    productInventoryUpdates.Add(new UpdateOneModel<InventoryCompanyEN>(filter, update) { IsUpsert = true });
                }

                // Insertar en la colección PurchaseProduct
                await _purcharseProductCollection.InsertManyAsync(purchaseProducts);

                // Ejecutar las actualizaciones en la colección InventoryCompany
                if (productInventoryUpdates.Any())
                {
                    await _inventoryCollection.BulkWriteAsync(productInventoryUpdates);
                }

                return purcharse._id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar en la base de datos: {ex.ToString()}");
                throw;
            }
        }

        public async Task DeletePurchaseTransactionAsync(string id)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p._id, id);
            await _purchaseCollection.DeleteOneAsync(filter);
        }

        public async Task<Purchase> GetExistingTransactionAsync(object userId, object companyId)
        {
            var filter = Builders<Purchase>.Filter.And(
                Builders<Purchase>.Filter.Eq(p => p.UserId, userId),
                Builders<Purchase>.Filter.Eq(p => p.CompanyId, (int)companyId)
            );

            return await _purchaseCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Purchase> GetPurchaseTransactionByIdAsync(string id)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p._id, id);
            return await _purchaseCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Purchase>> GetTransactionsByCompanyAsync(int companyId)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p.CompanyId, companyId);
            return await _purchaseCollection.Find(filter).ToListAsync();
        }

       public async Task<List<Purchase>> GetTransactionsByProviderAsync(string providerId)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p.ProviderId, providerId);
            return await _purchaseCollection.Find(filter).ToListAsync();
        }

        public async Task<List<Purchase>> GetTransactionsByUserAsync(object userId)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p.UserId, userId);
            return await _purchaseCollection.Find(filter).ToListAsync();
        }

        public async Task UpdatePurchaseTransactionAsync(Purchase existingTransaction)
        {
            var filter = Builders<Purchase>.Filter.Eq(p => p._id, existingTransaction._id);
            await _purchaseCollection.ReplaceOneAsync(filter, existingTransaction);
        }
    }
}
