using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class InventoryDTOs
    {
        public class InventoryStoreDto
        {
            public int StoreId { get; set; }
            public string ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class InventoryCompanyDto
        {
            public int CompanyId { get; set; }
            public string ProductId { get; set; }
            public int Quantity { get; set; }
        }

    }
}
