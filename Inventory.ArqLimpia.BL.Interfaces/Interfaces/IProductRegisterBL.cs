using Inventory.ArqLimpia.BL.DTOs;
using static Inventory.ArqLimpia.BL.DTOs.ProductRegisterDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces;

public interface IProductRegisterBL
{
    Task<List<ProductRegisterEN>> FindAllByCompanyId(string companyId);
    Task<List<ProductRegisterEN>> FindAllByName(string name);
}
