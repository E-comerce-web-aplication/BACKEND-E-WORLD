using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventary.ArqLimpia.DAL
{
    public class InventoryDAL : IInventory
    {
        private readonly IMongoCollection<InventoryStoreEN> _inventoryStoreCollection;
        private readonly IMongoCollection<InventoryCompanyEN> _inventoryCompanyCollection;

        public InventoryDAL(InventoryContextDAL dbContext)
        {
            _inventoryStoreCollection = dbContext.InventoryStore;
            _inventoryCompanyCollection = dbContext.InventoryCompany;
        }
        public async Task<List<InventoryCompanyEN>> FindAllCompanies(int companyId)
        {
            var filter = Builders<InventoryCompanyEN>.Filter.Eq("CompanyId", companyId);
            return _inventoryCompanyCollection.Find(filter).ToList();
        }

        public async Task<List<InventoryStoreEN>> FindAllStores(int storeId)
        {
            var filter = Builders<InventoryStoreEN>.Filter.Eq("StoreId", storeId);
            return _inventoryStoreCollection.Find(filter).ToList();
        }
    }
}
