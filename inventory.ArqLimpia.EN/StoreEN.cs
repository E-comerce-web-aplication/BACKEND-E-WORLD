using Inventory.ArqLimpia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class StoreEN
    {
        public int Id { get; set; }

        public string Address { get; set; }
        
        public virtual ICollection<ProductStoreEN> StoreProducts { get; set; }
        
        public virtual ICollection<OrdersEN> StoreOrders { get; set; }

        public virtual  ICollection<UserStoreEN> Users { get; set; }

        public virtual ICollection<ReturnsEN> StoreReturns { get; set; }
    }
}