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
        Task<List<ProductRegisterEN>> FindAll(string CompanyId, string UserName);
    }
}
