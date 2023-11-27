using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IPurcharseBL
    {
        Task<string> CreatePurchaseTransactionAsync(PurcharseProductsDTOs purchaseTransaction);
        Task DeletePurchaseTransactionAsync(string Id);
        Task<List<PurcharseOutputDTO>> GetTransactionsByCompanyAsync(int companyId);
    }
}

