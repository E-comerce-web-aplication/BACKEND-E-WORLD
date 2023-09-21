using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class OrdersEN
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int IdStore { get; set; }

        public int IdUser { get; set; }

        public virtual StoreEN Store { get; set; }

        public virtual UserStoreEN User { get; set; }

        public virtual ICollection<OrdersProductEN> EspecifiOrder { get; set; }
    }
}