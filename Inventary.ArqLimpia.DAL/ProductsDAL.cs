using inventory.ArqLimpia.EN;
using Inventory.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventary.ArqLimpia.DAL
{
    public class ProductsDAL : IProduct
    {
        readonly InventoryContextDAL dbContext;

        public ProductsDAL(InventoryContextDAL pdbContext)
        {
            dbContext = pdbContext;
        }

        public void Create(ProductEN pProducts)
        {
            dbContext.Products.Add(pProducts);
        }

        public void Delete(ProductEN pProducts)
        {
            dbContext.Products.Remove(pProducts);
        }

        public async Task<List<ProductEN>> Find(ProductEN pProduct)
        {
            List<ProductEN> isProducts = await dbContext.Products.ToListAsync();
            return isProducts;
        }

     

        public async Task<ProductEN> FindByName(ProductEN pProducts)
        {
            ProductEN isProduct = await dbContext.Products.SingleOrDefaultAsync(p=> p.ProductName == pProducts.ProductName);
            return isProduct;
        }

        public async Task<ProductEN> FindOne(int productId)
        {
            ProductEN isProduct = await dbContext.Products.FindAsync(productId);
            return isProduct;
        }

        public void Update(ProductEN pProducts)
        {
            dbContext.Products.Update(pProducts);
        }
    }
}
