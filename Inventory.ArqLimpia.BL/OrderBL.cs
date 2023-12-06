
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
                // Llama al m�todo AuthorizeReturn para obtener la informaci�n de la devoluci�n
                var orderItem = await _orderDAL.AuthorizeOrder(orderId);

                // Verificar si la devoluci�n no existe
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

        public async Task<List<OrderDto>> FindAllOrders(int storeId)
        {
             try
            {
                var stores = await _orderDAL.FindAllOrders(storeId);

                if (stores?.Any() == true)
                {
                    var dtos = stores.Select(store => new OrderDto
                    {
                        StoreId = store.StoreId
                       
                    }).ToList();

                    return dtos;
                }

                throw new Exception($"No se encontraron tiendas para el ID {storeId}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}