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
                    UserId = orderInput.UserId,
                    Total = orderInput.Total,
                    Status = ConvertToOrderStatus(orderInput.Status)
                };

                // Insertar la orden y luego obtener su ID
                await _ordersCollection.InsertOneAsync(order);

                // Ahora que la orden tiene un ID, actualiza el campo OrderId en orderProducts
                var orderProducts = new List<OrdersProductEN>();
                foreach (var productInput in orderInput.Products)
                {
                    var orderProduct = new OrdersProductEN
                    {
                        ProductId = productInput.ProductId,
                        OrderId = order._id, // Utilizar el ID de la orden recién creada
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

        private async Task UpdateCompanyInventory(List<OrderProductInputDTOs> products)
        {
            foreach (var productInput in products)
            {
                var filter = Builders<InventoryCompanyEN>.Filter.Eq("ProductId", productInput.ProductId);
                var update = Builders<InventoryCompanyEN>.Update.Inc("Quantity", -productInput.Quantity);
                await _inventoryCompanyCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
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

        public async Task<OrdersEN> AuthorizeOrder(string orderId)
        {
            try
            {
                var filter = Builders<OrdersEN>.Filter.Eq("_id", ObjectId.Parse(orderId));
                var orderResult = await _ordersCollection.FindAsync(filter);
                var orderEntity = await orderResult.SingleOrDefaultAsync();

                if (orderEntity == null)
                {
                    throw new Exception("Orden no encontrada");
                }

                // Verificar si la orden ya fue autorizada
                if (orderEntity.Status == OrderStatus.Confirmed)
                {
                    throw new Exception("La orden ya fue autorizada anteriormente");
                }

                // Actualizar el estado de la orden a "Confirmada"
                var updateStatus = Builders<OrdersEN>.Update.Set("Status", OrderStatus.Confirmed);
                await _ordersCollection.UpdateOneAsync(filter, updateStatus);

                // Obtener la lista de productos de la orden
                var ordersProducts = await _ordersProductCollection
                    .Find(Builders<OrdersProductEN>.Filter.Eq("Orders", orderEntity._id))
                    .ToListAsync();

                // Convertir la lista de OrdersProductEN a OrderProductInputDTOs
                var productsDTOs = ordersProducts.Select(product => new OrderProductInputDTOs
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity
                }).ToList();

                // Actualizar el inventario de la compañía
                await UpdateCompanyInventory(productsDTOs);

                // Actualizar el inventario de la tienda
                await UpdateStoreInventory(orderEntity.StoreId, productsDTOs);

                // Devolver la entidad de la orden
                return orderEntity;
            }
            catch (Exception ex)
            {
                throw ex;
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
