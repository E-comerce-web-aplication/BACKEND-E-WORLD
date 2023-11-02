using Inventory.ArqLimpia.BL.DTOs;
using static Inventory.ArqLimpia.BL.DTOs.ProductHistoryDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IProductHistory
    {
        Task<DeleteHistoryOutputDTOs> Delete(DeleteHistoryInputDTOs pHistory);
        Task<List<FindOneHistoryOutputDTOs>> Find(FindHistoryOutputDTOs pHistory);
        Task<FindOneHistoryOutputDTOs> FindOne(FindByIdDTO pHistory);
    }
}
