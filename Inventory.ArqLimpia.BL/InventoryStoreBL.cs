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
    public class InventoryStoreBL : IInventoryStoreBL


    {
        public Task<int> Find(InventoryStoreDTOs.FindInventoryStoreOutputDTO PInventory)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryStoreDTOs.FindOneInventoryStoreOutputDTO> FindOne(InventoryStoreDTOs.FindOneInventoryStoreInputDTO PInventory)
        {
            throw new NotImplementedException();
        }
    }
}
