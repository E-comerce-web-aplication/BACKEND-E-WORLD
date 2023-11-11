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
        private readonly IMongoCollection<ProductEN> _productsCollection;

        public OrderDAL(InventoryContextDAL dbContext)
        {
            _ordersCollection = dbContext.Orders;
            _ordersProductCollection = dbContext.OrderProducts;
            _productsCollection = dbContext.Products;
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
                    Total = orderInput.Total
                };
                await _ordersCollection.InsertOneAsync(order);

                var orderProducts = new List<OrdersProductEN>();
                foreach (var productInput in orderInput.Products)
                {
                    var orderProduct = new OrdersProductEN
                    {
                        ProductId = productInput.ProductId,
                        OrderId = order.Id, 
                        Quantity = productInput.Quantity,
                    };
                    orderProducts.Add(orderProduct);
                }
                await _ordersProductCollection.InsertManyAsync(orderProducts);

                foreach (var productInput in orderInput.Products)
                {
                    var product = await _productsCollection.Find(p => p._id == productInput.ProductId).FirstOrDefaultAsync();

                    var newStock = product.Stock - productInput.Quantity;

                    if (newStock >= 0)
                    {
                        var filter = Builders<ProductEN>.Filter.Eq(p => p._id, productInput.ProductId);
                        var update = Builders<ProductEN>.Update.Set(p => p.Stock, newStock);

                        await _productsCollection.UpdateOneAsync(filter, update);
                    }
                    else
                    {
                        throw new Exception("Insufficient stock for product: " + product.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<OrdersEN>> Find()
        {
            var filter = Builders<OrdersEN>.Filter.Empty; // Filtro vacío para obtener todos los documentos
            var result = await _ordersCollection.FindAsync(filter);
            return await result.ToListAsync();
        }
    }
}

