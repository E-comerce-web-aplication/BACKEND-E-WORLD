using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IPurchases
    {
        Task<string> CreatePurchaseTransactionAsync(PurchaseProductEN purchaseTransaction);
        Task DeletePurchaseTransactionAsync(string Id);
        Task<PurchaseProductEN> GetExistingTransactionAsync(object userId, object companyId);
        Task<PurchaseProductEN> GetPurchaseTransactionByIdAsync(string Id);
        Task<List<PurchaseProductEN>> GetTransactionsByCompanyAsync(int companyId);
        Task<List<PurchaseProductEN>> GetTransactionsByProviderAsync(string providerId);
        Task<List<PurchaseProductEN>> GetTransactionsByUserAsync(int userId);
        Task UpdatePurchaseTransactionAsync(PurchaseProductEN existingTransaction);
    }
}
