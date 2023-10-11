using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;

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
