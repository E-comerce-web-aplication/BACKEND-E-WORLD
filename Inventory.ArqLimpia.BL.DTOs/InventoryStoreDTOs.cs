using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class InventoryStoreDTOs
    {
     
        public class FindOneInventoryStoreInputDTO
        {
            [Required]

            public int  IdStore { get; set; }

        }

        public class FindOneInventoryStoreOutputDTO
        {
            [Required]
            public int ProductStore { get; set; }


        }

        public class FindInventoryStoreOutputDTO

        {
            
            public int  IdStore  { get; set; }
            
            public int IdProduct { get; set; }

           
            public string ProductName { get; set; }

            
            public string Descriptions { get; set; }


            
            public int Stock { get; set; }

            
            public decimal Price { get; set; }

        }


        


    }
}
