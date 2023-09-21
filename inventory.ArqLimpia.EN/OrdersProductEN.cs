using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class OrdersProductEN
    {
        public int Id { get; set; }

        public int IdProduct { get; set; }

        public int IdOrder { get; set; }

        public int Quantity { get; set; }

        public virtual  ProductEN Product { get; set; }

        public virtual OrdersEN Order { get; set; }
    }
}