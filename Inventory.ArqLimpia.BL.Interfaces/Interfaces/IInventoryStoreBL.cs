using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.ArqLimpia.BL.DTOs;
using static Inventory.ArqLimpia.BL.DTOs.InventoryStoreDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public  interface IInventoryStoreBL
    {
        Task<FindOneInventoryStoreOutputDTO> FindOne(FindOneInventoryStoreInputDTO PInventory);
        Task<int> Find(FindInventoryStoreOutputDTO PInventory );
        

    }
}
