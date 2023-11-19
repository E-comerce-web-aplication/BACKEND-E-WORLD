
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using static Inventory.ArqLimpia.BL.DTOs.InventoryDTOs;

namespace Inventory.ArqLimpia.BL
{
    public class InventoryBL : IInventoryBL
    {
        readonly IInventory _inventoryDAL;

        public InventoryBL(IInventory inventoryDAL)
        {
            _inventoryDAL = inventoryDAL;
        }

        public async Task<List<InventoryCompanyDto>> FindAllCompanies(int companyId)
        {
            try
            {
                var companies = await _inventoryDAL.FindAllCompanies(companyId);

                if (companies?.Any() == true)
                {
                    var dtos = companies.Select(company => new InventoryCompanyDto
                    {
                        CompanyId = company.CompanyId,
                        ProductId = company.ProductId.ToString(),
                        Quantity = company.Quantity
                        
                    }).ToList();

                    return dtos;
                }

                throw new Exception($"No se encontraron compañías para el ID {companyId}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<InventoryStoreDto>> FindAllStores(int storeId)
        {
            try
            {
                var stores = await _inventoryDAL.FindAllStores(storeId);

                if (stores?.Any() == true)
                {
                    var dtos = stores.Select(store => new InventoryStoreDto
                    {
                        StoreId = store.StoreId,
                        ProductId = store.ProductId.ToString(),
                        Quantity = store.Quantity
                       
                    }).ToList();

                    return dtos;
                }

                throw new Exception($"No se encontraron tiendas para el ID {storeId}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
