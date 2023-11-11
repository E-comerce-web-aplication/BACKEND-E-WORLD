 
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.EN.Enterprice;

namespace Inventory.ArqLimpia.BL
{
    public class OrderBL : IOrderBL
    {
        readonly IOrder _orderDAL;
        
        public OrderBL(IOrder orderDAL){
            _orderDAL = orderDAL;
        }

        public async Task<CreateOrderOutputDTOs> Create(CreateOrderInputDTOs order)
        {
            await _orderDAL.Create(order);

            var createdOrder = new CreateOrderOutputDTOs
            {
                OrderDate = order.OrderDate,
                StoreId = order.StoreId,
                CustomerId = order.CustomerId,
                Total = order.Total
            };

            return createdOrder;
        }

        public async Task<List<FindOrderOutputDTOs>> Find()
        {
            var orders = await _orderDAL.Find();

            var resultList = orders.Select(order => new FindOrderOutputDTOs
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                StoreId = order.StoreId,
                CustomerId = order.CustomerId,
                Total = order.Total
            }).ToList();

            return resultList;
        }
    }
}