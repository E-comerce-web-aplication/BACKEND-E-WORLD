 
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.EN.Enterprice;
using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;

namespace Inventory.ArqLimpia.BL
{
    public class OrderBL : IOrderBL
    {
        readonly IOrder _orderDAL;

        public OrderBL(IOrder orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public async Task<CreateOrderOutputDTOs> Create(CreateOrderInputDTOs order)
        {
            await _orderDAL.Create(order);

            var createdOrder = new CreateOrderOutputDTOs
            {
                OrderDate = order.OrderDate,
                StoreId = order.StoreId,
                UserId = order.UserId,
                Total = order.Total,
                Status = order.Status
            };

            return createdOrder;
        }
    
        public async Task<FindOrderOutputDTOs> Find(string orderId)
        {

            try
            {
                // Llama al método AuthorizeReturn para obtener la información de la devolución
                var orderItem = await _orderDAL.AuthorizeOrder(orderId);

                // Verificar si la devolución no existe
                if (orderItem == null)
                {
                    return null;
                }

                // Crear el objeto de salida
                var result = new FindOrderOutputDTOs
                {
                    Id = orderItem._id,
                    OrderDate = orderItem.OrderDate,
                    StoreId = orderItem.StoreId,
                    UserId = orderItem.UserId,
                    Total = orderItem.Total,
                    Status = orderItem.Status.ToString()
                };

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}