
using static Inventory.ArqLimpia.BL.DTOs.InventoryDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IInventoryBL
    {
        Task<List<InventoryStoreDto>> FindAllStores(int storeId);
        Task<List<InventoryCompanyDto>> FindAllCompanies(int companyId);
    }
}
