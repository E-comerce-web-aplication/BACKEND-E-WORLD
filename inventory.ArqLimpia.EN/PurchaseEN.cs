using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class PurchaseEN
    {
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
    }
}
