using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.EN.Enterprice
{
    public interface IOrder
    {
        Task Create( CreateOrderInputDTOs Order );  
        Task<List<FindOrderOutputDTOs>> Find();   
    }
}