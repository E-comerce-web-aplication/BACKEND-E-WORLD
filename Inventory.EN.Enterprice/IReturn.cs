using inventory.ArqLimpia.EN;

using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IReturn
    {
        Task Create(CreateReturnInputDTO pReturn);
        Task<List<ReturnEN>> Find();
    }
}
