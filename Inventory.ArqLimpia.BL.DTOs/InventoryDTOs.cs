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
            public object ProductInfo { get; set; }
            public int Quantity { get; set; }
        }

        public class ProductInformationDTO
        {
           public string Title { get; set; }

           public List<string> Images { get; set; }

           public string ProductName { get; set; }
        
           public double Price { get; set; }
           
           
        }

    }
}
