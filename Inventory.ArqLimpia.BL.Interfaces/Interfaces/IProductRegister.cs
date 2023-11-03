using Inventory.ArqLimpia.BL.DTOs;
using static Inventory.ArqLimpia.BL.DTOs.ProductRegisterDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces;

public  interface IProductRegister
{
    Task<FindQueryProductRegisterDTOs> FindQuery(FindQueryProductRegisterDTOs pRegister);
    Task<FindAllProductRegisterDTOs> FindAll(FindAllProductRegisterDTOs pRegister);
    Task<FindByIdProductRegisterDTOs> FindById(FindByIdProductRegisterDTOs pRegister);
}
