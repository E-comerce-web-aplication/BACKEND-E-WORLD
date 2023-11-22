using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IPurchases
    {
        Task CreateNormalBuyAsync();
        Task CreateUniqueBuyAsync();
        Task<IEnumerable<SinglePurchaseEN>> FindAllNormalBuyAsync();
        Task<IEnumerable<PurchaseEN>> FindAllUniqueBuyAsync();
    }
}
