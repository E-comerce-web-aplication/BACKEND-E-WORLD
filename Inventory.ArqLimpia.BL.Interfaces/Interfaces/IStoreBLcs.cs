using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.ArqLimpia.BL.DTOs;
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
