using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IPurcharseBL
    {
        Task<string> CreatePurchaseTransactionAsync(PurcharseProductsDTOs purchaseTransaction);
        Task<PurcharseProductsDTOs> GetPurchaseTransactionByIdAsync(string Id);
        Task<List<PurcharseProductsDTOs>> GetTransactionsByUserAsync(int userId);
        Task DeletePurchaseTransactionAsync(string Id);
        Task<List<PurcharseProductsDTOs>> GetTransactionsByCompanyAsync(int companyId);
        Task<List<PurcharseProductsDTOs>> GetTransactionsByProviderAsync(string providerId);
    }
}

