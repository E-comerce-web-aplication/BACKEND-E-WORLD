using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory.ArqLimpia.EN
{
    public class ProductStoreEN
    {
        public int Id { get; set; }

        public int IdProduct { get; set;}

        public int IdStore { get; set; }
        
        public int BelogingStock { get; set; }

        public  virtual StoreEN Store { get; set; }

        public virtual ProductEN Product { get; set; }
    }
}