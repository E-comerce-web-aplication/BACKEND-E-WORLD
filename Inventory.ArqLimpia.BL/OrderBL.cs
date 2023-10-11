
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.EN.Enterprice;

namespace Inventory.ArqLimpia.BL
{
    public class OrderBL : IOrderBL
    {
        readonly IOrder _orderDAL;
        
        public OrderBL(IOrder orderDAL){
            _orderDAL = orderDAL;
        }

        public Task<CreateOrderOutputDTOs> Create(CreateOrderInputDTOs pProducts)
        {
            throw new NotImplementedException();
        }

        public Task<List<FindOrderOutputDTOs>> Find()
        {
            throw new NotImplementedException();
        }
    }
}