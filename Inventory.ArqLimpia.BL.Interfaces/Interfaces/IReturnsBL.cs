using Inventory.ArqLimpia.BL.DTOs;
using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;
namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public  interface IReturns
    {
        Task<CreateReturnOutputDTO> Create(CreateReturnInputDTO pReturn);
        Task<FindReturnOutputDTOs> Find(string returnId);
    }
}
