using Inventory.ArqLimpia.BL.DTOs;


namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IProductHistory
    {
        Task<DeleteHistoryOutputDTOs> Delete(DeleteHistoryInputDTOs pProducts);
        Task<List<FindOneHistoryOutputDTOs>> Find(FindHistoryOutputDTOs pProducts);
        Task<FindOneHystoryOutputDTOs> FindOne(FindByIdDTOs pProducts);
    }
}
