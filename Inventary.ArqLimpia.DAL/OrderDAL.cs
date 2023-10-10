using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN;
using Inventory.EN.Enterprice;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class OrderDAL : IOrder
    {
        private readonly IMongoCollection<OrdersEN> _collection;

        public OrderDAL(InventoryContextDAL dbContext)
        {
            _collection = dbContext.Orders;
        }

        public Task Create(CreateOrderInputDTOs Order)
        {
            throw new NotImplementedException();
        }

        public Task<List<FindOrderOutputDTOs>> Find()
        {
            throw new NotImplementedException();
        }
    }
}