using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using MongoDB.Driver;

namespace Inventary.ArqLimpia.DAL
{
    public class PurchasesDAL : IPurchases
    {
        private readonly IMongoCollection<PurchaseEN> _purcharse;
        private readonly IMongoCollection<PurchaseProductEN> _purcharseProduct;
        private readonly IMongoCollection<SinglePurchaseEN> _singlePurcharse;

        public PurchasesDAL(InventoryContextDAL dbContext)
        {
            _purcharse = dbContext.Purchase;
            _purcharseProduct = dbContext.PurchaseProduct;
            _singlePurcharse = dbContext.SinglePurchase;
        }

        public Task CreateNormalBuyAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateUniqueBuyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SinglePurchaseEN>> FindAllNormalBuyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PurchaseEN>> FindAllUniqueBuyAsync()
        {
            throw new NotImplementedException();
        }
    }
}
