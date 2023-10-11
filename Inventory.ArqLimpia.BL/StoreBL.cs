using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;


namespace Inventory.ArqLimpia.BL
{
    public class StoreBL : IStoreBLcs
    {
        public Task<StoreDTOs.FindProductStoreOutputDTO> FindProduct(StoreDTOs.FindProductStoretInputDTO pStore)
        {
            throw new NotImplementedException();
        }

        public Task<StoreDTOs.FindUserStoreOutputDTO> FindUSer(StoreDTOs.FindUserStoreInputDTO pStore)
        {
            throw new NotImplementedException();
        }

        public Task<StoreDTOs.InfoStoreOutputDTO> InfoStore(StoreDTOs.InfoStoreInputDTO pStore)
        {
            throw new NotImplementedException();
        }
    }
}
