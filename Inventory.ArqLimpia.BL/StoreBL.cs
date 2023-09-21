using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;
using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;


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
