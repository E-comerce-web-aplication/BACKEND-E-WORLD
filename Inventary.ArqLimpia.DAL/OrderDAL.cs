using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN;
using Inventory.EN.Enterprice;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Inventary.ArqLimpia.DAL
{
    public class OrderDAL : IOrder
    {
        private readonly IMongoCollection<OrdersEN> _ordersCollection;
        private readonly IMongoCollection<OrdersProductEN> _ordersProductCollection;
        private readonly IMongoCollection<InventoryCompanyEN> _inventoryCompanyCollection;
        private readonly IMongoCollection<InventoryStoreEN> _inventoryStoreCollection;

        public OrderDAL(InventoryContextDAL dbContext)
        {
            _ordersCollection = dbContext.Orders;
            _ordersProductCollection = dbContext.OrderProduct;
            _inventoryCompanyCollection = dbContext.InventoryCompany;
            _inventoryStoreCollection = dbContext.InventoryStore;
        }

        public async Task Create(CreateOrderInputDTOs orderInput)
        {
            try
            {
                var order = new OrdersEN
                {
                    OrderDate = DateTime.Now,
                    StoreId = orderInput.StoreId,
                    CustomerId = orderInput.CustomerId,
                    Total = orderInput.Total,
                    Status = ConvertToOrderStatus(orderInput.Status)
                };
                await _ordersCollection.InsertOneAsync(order);

                var orderProducts = new List<OrdersProductEN>();
                foreach (var productInput in orderInput.Products)
                {
                    var orderProduct = new OrdersProductEN
                    {
                        ProductId = productInput.ProductId,
                        OrderId = order._id,
                        Quantity = productInput.Quantity,
                    };
                    orderProducts.Add(orderProduct);
                }
                await _ordersProductCollection.InsertManyAsync(orderProducts);
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdersEN> AuthorizeOrder(string orderId)
        {
            try
            {
                var filter = Builders<OrdersEN>.Filter.Eq("_id", ObjectId.Parse(orderId));
                var orderResult = await _ordersCollection.FindAsync(filter);
                var orderEntity = await orderResult.SingleOrDefaultAsync();

                if (orderEntity == null)
                {
                    // Manejar el caso donde no se encuentra la devolución
                    // Puedes lanzar una excepción, loggear un error, etc.
                    throw new Exception("Orden no encontrada");
                }

                // Verificar si la devolución ya fue autorizada
                if (orderEntity.Status == OrderStatus.Confirmed)
                {
                    // Manejar el caso donde la devolución ya fue autorizada
                    // Puedes lanzar una excepción, loggear un error, etc.
                    throw new Exception("La orden ya fue autorizada anteriormente");
                }

                // Actualizar el estado de la devolución a "Confirmada"
                var updateStatus = Builders<OrdersEN>.Update.Set("Status", OrderStatus.Confirmed);
                await _ordersCollection.UpdateOneAsync(filter, updateStatus);

                // Obtener la lista de productos devueltos
                var ordersProducts = await _ordersProductCollection
                    .Find(Builders<OrdersProductEN>.Filter.Eq("Orders", orderEntity._id))
                    .ToListAsync();

                // Convertir la lista de ProductReturnEN a ReturnProductsInputDTOs
                var productsDTOs = ordersProducts.Select(product => new OrderProductInputDTOs
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity
                }).ToList();


                // Actualizar el inventario de la compañía
                await UpdateCompanyInventory(productsDTOs);

                // Actualizar el inventario de la tienda
                await UpdateStoreInventory(orderEntity.StoreId, productsDTOs);

                // Devolver la entidad de devolución
                return orderEntity;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, puedes loggear el error, lanzar otra excepción, etc.
                throw ex;
            }
        }


        private async Task UpdateCompanyInventory(List<OrderProductInputDTOs> products)
        {
            foreach (var productInput in products)
            {
                var filter = Builders<InventoryCompanyEN>.Filter.Eq("ProductId", productInput.ProductId);
                var update = Builders<InventoryCompanyEN>.Update.Inc("Quantity", -productInput.Quantity);
                await _inventoryCompanyCollection.UpdateOneAsync(filter, update);
            }
        }

        private async Task UpdateStoreInventory(int storeId, List<OrderProductInputDTOs> products)
        {
            foreach (var productInput in products)
            {
                var filter = Builders<InventoryStoreEN>.Filter.And(
                    Builders<InventoryStoreEN>.Filter.Eq("StoreId", storeId),
                    Builders<InventoryStoreEN>.Filter.Eq("ProductId", productInput.ProductId));

                var update = Builders<InventoryStoreEN>.Update.Inc("Quantity", productInput.Quantity);
                await _inventoryStoreCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
            }
        }

        private OrderStatus ConvertToOrderStatus(string status)
        {
            switch (status.ToLower())
            {
                case "pending":
                    return OrderStatus.Pending;
                case "rejected":
                    return OrderStatus.Rejected;
                case "confirmed":
                    return OrderStatus.Confirmed;
                default:
                    throw new ArgumentException("Estado de pedido no válido");
            }
        }
    }
}
