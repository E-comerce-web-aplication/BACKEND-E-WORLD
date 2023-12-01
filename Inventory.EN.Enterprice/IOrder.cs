using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.EN;

namespace Inventory.EN.Enterprice
{
    public interface IOrder
    {
        Task Create( CreateOrderInputDTOs Order );  
        Task<List<OrdersEN>> Find();
      
    }
}