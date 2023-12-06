using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Bson;
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

        public async Task<ReturnEN> AuthorizeReturn(string returnId)
        {
            try
            {
                var filter = Builders<ReturnEN>.Filter.Eq("_id", ObjectId.Parse(returnId));
                var updateStatus = Builders<ReturnEN>.Update.Set("Status", ReturnStatus.Confirmed);

                // Actualizar el estado de la orden a "Confirmada"
                var returnEntity = await _returnCollection.FindOneAndUpdateAsync(
                    filter,
                    updateStatus,
                    new FindOneAndUpdateOptions<ReturnEN, ReturnEN> { ReturnDocument = ReturnDocument.After });

                if (returnEntity == null)
                {
                    throw new Exception("Retorno no encontrada");
                }

                // Obtener la lista de productos de la orden
                var returnsProducts = await _returnProductCollection
                    .Find(Builders<ProductReturnEN>.Filter.Eq("Returns", returnEntity._id))
                    .ToListAsync();

                // Convertir la lista de ProductReturnEN a ReturnProductsInputDTOs
                var returnDTOs = returnsProducts.Select(product => new ReturnProductsInputDTOs
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity
                }).ToList();


                // Actualizar el inventario de la compañía
                await UpdateCompanyInventory(returnDTOs);

                // Actualizar el inventario de la tienda
                await UpdateStoreInventory(returnEntity.StoreId, returnDTOs);

                // Devolver la entidad de la orden
                return returnEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
