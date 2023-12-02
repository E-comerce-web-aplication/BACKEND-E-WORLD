using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;
using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;

namespace Inventary.ArqLimpia.DAL
{
    public class ReturnDAL: IReturn
    {
        private readonly IMongoCollection<ReturnEN> _returnCollection;
        private readonly IMongoCollection<ProductReturnEN> _returnProductCollection;
        private readonly IMongoCollection<InventoryCompanyEN> _inventoryCompanyCollection;
        private readonly IMongoCollection<InventoryStoreEN> _inventoryStoreCollection;

        public ReturnDAL(InventoryContextDAL dbContext)
        {
            _returnCollection = dbContext.Return;
            _inventoryCompanyCollection = dbContext.InventoryCompany;
            _inventoryStoreCollection = dbContext.InventoryStore;
            _returnProductCollection = dbContext.ProductReturn;
        }

        public async Task Create(CreateReturnInputDTO returnInput)
        {
            try
            {
                var newReturn = new ReturnEN
                {
                    Date = DateTime.Now,
                    UserId = returnInput.UserId,
                    Reason = returnInput.Reason,
                    StoreId = returnInput.StoreId,
                    Total = returnInput.Total,
                    Status = ConvertToReturnStatus(returnInput.Status)
                };

                await _returnCollection.InsertOneAsync(newReturn);

                var returnProducts = new List<ProductReturnEN>();
                foreach (var productInput in returnInput.Products)
                {
                    var returnProduct = new ProductReturnEN
                    {
                        ProductId = productInput.ProductId,
                        Returns = newReturn._id,
                        Quantity = productInput.Quantity,
                    };
                    returnProducts.Add(returnProduct);
                }
                await _returnProductCollection.InsertManyAsync(returnProducts);

                // Actualizar el inventario de la compañía
                await UpdateCompanyInventory(returnInput.Products.ToList());

                // Actualizar el inventario de la tienda
                await UpdateStoreInventory(returnInput.StoreId, returnInput.Products.ToList());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateStoreInventory(int storeId, List<ReturnProductsInputDTOs> products)
        {
            foreach (var productInput in products)
            {
                var filter = Builders<InventoryStoreEN>.Filter.And(
                    Builders<InventoryStoreEN>.Filter.Eq("StoreId", storeId),
                    Builders<InventoryStoreEN>.Filter.Eq("ProductId", productInput.ProductId));

                var update = Builders<InventoryStoreEN>.Update.Inc("Quantity", -productInput.Quantity);
                await _inventoryStoreCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
            }
        }

        private async Task UpdateCompanyInventory(List<ReturnProductsInputDTOs> products)
        {
            foreach (var productInput in products)
            {
                var filter = Builders<InventoryCompanyEN>.Filter.Eq("ProductId", productInput.ProductId);
                var update = Builders<InventoryCompanyEN>.Update.Inc("Quantity", productInput.Quantity);
                await _inventoryCompanyCollection.UpdateOneAsync(filter, update);
            }
        }


        public async Task<List<ReturnEN>> Find()
        {
            var filter = Builders<ReturnEN>.Filter.Empty;
            var result = await _returnCollection.FindAsync(filter);
            return await result.ToListAsync();
        }

        private ReturnStatus ConvertToReturnStatus(string status)
        {
            switch (status.ToLower())
            {
                case "pending":
                    return ReturnStatus.Pending;
                case "rejected":
                    return ReturnStatus.Rejected;
                case "confirmed":
                    return ReturnStatus.Confirmed;
                default:
                    throw new ArgumentException("Estado de pedido no válido");
            }
        }

    }
}
