using Inventory.ArqLimpia.BL.DTOs;


namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IProviderBL
    {
        Task<CreateProviderOutputDTOs> CreateProvider(CreateProviderInputDTOs pProvider);
        Task<UpdateProviderOutputDTOs> Update(UpdateProviderInputDTOs pProvider);
        Task<DeleteProviderOutputDTOs> Delete(DeleteProviderInputDTOs pProvider);
        Task<List<FindOneProviderOutputDTOs>> Find(FindProviderOutputDTOs pProvider);
        Task<FindOneProviderOutputDTOs> FindOne(FindByIdProviderDTOs pProvider);
    }
}
