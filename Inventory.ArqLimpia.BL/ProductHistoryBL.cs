using Inventary.ArqLimpia.DAL;
using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using static Inventory.ArqLimpia.BL.DTOs.ProductHistoryDTOs;

namespace Inventory.ArqLimpia.BL
{
    public class ProductHistoryBL : IProductHistoryBL
    {
        readonly IProducHistory _productHistoryDAL;

        public ProductHistoryBL(IProducHistory productHistoryDAL)
        {
            _productHistoryDAL = productHistoryDAL;
        }

        public async Task<List<ProductHistoryDTOs.FindAllOutputDTOs>> FindAll(ProductHistoryDTOs.FindAllOutputDTOs pHistory)
        {
            var historyList = await _productHistoryDAL.FindAll(pHistory.CompanyId);
            if (historyList != null)
            {
                var productHistoryList = historyList.Select(history => new ProductHistoryDTOs.FindAllOutputDTOs
                {
                    Id = history._id,
                    ProductName = history.ProductName,
                    Title = history.Title,
                    Description = history.Description,
                    Images = history.Images,
                    Stock = history.Stock,
                    Price = history.Price,
                    CompanyId = history.CompanyId,
                    SendConditions = history.SendConditions
                }).ToList();

                return productHistoryList;
            }

            throw new Exception($"Productos con CompanyId {pHistory.CompanyId} no encontrados");
        }
    }
}
