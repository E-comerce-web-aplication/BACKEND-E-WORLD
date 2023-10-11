using Inventory.ArqLimpia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class UserStoreEN
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdStore { get; set; }

        // public virtual ICollection<OrdersEN> UserOrders { get; set; }

        public virtual ICollection<ReturnsEN> UserReturns { get; set; }

        public virtual StoreEN BelogingStore { get; set; }

        public virtual UserEN UserInfo { get; set; }
    }
}