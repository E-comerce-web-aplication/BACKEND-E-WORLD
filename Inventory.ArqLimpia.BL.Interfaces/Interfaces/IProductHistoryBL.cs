using Inventory.ArqLimpia.BL.DTOs;
using static Inventory.ArqLimpia.BL.DTOs.ProductHistoryDTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IProductHistoryBL
    {  
        Task<List<FindAllOutputDTOs>> FindAll(FindAllOutputDTOs pHistory);
    }
}
