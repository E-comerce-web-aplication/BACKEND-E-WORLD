using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
       public class ProductEN
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Descriptions { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<ProductStoreEN> ProductStore { get; set; }
        
        public virtual ICollection<OrdersProductEN> ProductOrder { get; set; }
    }

    
}
