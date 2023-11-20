using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class PurchaseProductEN
    {
        public string PurchaseId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
