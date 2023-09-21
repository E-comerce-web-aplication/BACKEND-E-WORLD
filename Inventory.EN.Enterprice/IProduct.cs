using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using inventory.ArqLimpia.EN;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IProduct
    {
        void  Create(ProductEN pProducts);
        void Update(ProductEN pProducts);
        void Delete(ProductEN pProducts);
        Task<ProductEN> FindOne(int productId);
        Task<List<ProductEN>> Find(ProductEN pProduct);
        Task<ProductEN>  FindByName(ProductEN pProducts);
    }
}
