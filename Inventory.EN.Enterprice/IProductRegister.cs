using inventory.ArqLimpia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.EN.Interfaces
{
    public interface IProductRegister
    {
        Task<List<ProductRegisterEN>> FindAllByCompanyId(string companyId);
        Task<List<ProductRegisterEN>> FindAllByName(string name);
        Task RegistrarAccionEnProductRegisterEN(ProductEN producto, ProductType tipoAccion);
    }
}
