
using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IOrderBL
    {
        Task<CreateOrderOutputDTOs> Create(CreateOrderInputDTOs pProducts);
        Task<List<FindOrderOutputDTOs>> Find();
    }
}