using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IPurchases
    {
        Task<string> CreatePurchaseTransactionAsync(PurcharseProductsDTOs purcharse);
        Task DeletePurchaseTransactionAsync(string Id);
        Task<Purchase> GetExistingTransactionAsync(object userId, object companyId);
        Task<Purchase> GetPurchaseTransactionByIdAsync(string Id);
        Task<List<Purchase>> GetTransactionsByCompanyAsync(int companyId);
        Task<List<Purchase>> GetTransactionsByProviderAsync(string providerId);
        Task<List<Purchase>> GetTransactionsByUserAsync(object userId);
        Task UpdatePurchaseTransactionAsync(Purchase existingTransaction);
    }
}
