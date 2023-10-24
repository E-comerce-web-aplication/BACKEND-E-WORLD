 
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
            var _order = new CreateOrderOutputDTOs()
            {

                Status = order.Status,
                StoreId = order.StoreId,
                Total = order.Total,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate
            };
            return _order;
        }

        public async Task<List<FindOrderOutputDTOs>> Find()
        {
            var orders = await _orderDAL.Find();

            var resultList = new List<FindOrderOutputDTOs>();

            orders.ForEach(order => resultList.Add(new FindOrderOutputDTOs
            {
                Id = order.Id,
                StoreId = order.StoreId,
                Status = order.Status,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Total = order.Total
                
            }));

            return resultList;
        }
    }
}