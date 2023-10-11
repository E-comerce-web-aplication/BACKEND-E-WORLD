using static Inventory.ArqLimpia.BL.DTOs.StoreDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public  interface IStoreBLcs

    {
        Task <FindProductStoreOutputDTO > FindProduct (FindProductStoretInputDTO pStore);
        Task<FindUserStoreOutputDTO> FindUSer(FindUserStoreInputDTO pStore);
        Task<InfoStoreOutputDTO> InfoStore(InfoStoreInputDTO pStore);

    }
}
