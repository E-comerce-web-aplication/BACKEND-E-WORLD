using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN;
using Inventory.EN.Enterprice;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            _ordersProductCollection = dbContext.OrderProducts;
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

                // Actualizar el inventario de la compañía
                await UpdateCompanyInventory(orderInput.Products.ToList());

                // Actualizar el inventario de la tienda
                await UpdateStoreInventory(orderInput.StoreId, orderInput.Products.ToList());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrdersEN>> Find()
        {
            var filter = Builders<OrdersEN>.Filter.Empty;
            var result = await _ordersCollection.FindAsync(filter);
            return await result.ToListAsync();
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
