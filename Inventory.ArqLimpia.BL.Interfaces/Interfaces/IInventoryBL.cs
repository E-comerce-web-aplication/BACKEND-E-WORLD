using inventory.ArqLimpia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public interface IInventoryBL
    {
        List<InventoryStoreEN> FindAllStores(int storeId);
        List<InventoryCompanyEN> FindAllCompanies(int companyId);
    }
}
