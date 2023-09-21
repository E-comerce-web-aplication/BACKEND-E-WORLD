using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
     public  class StoreDTOs
        //DTO para buscar por tienda 
    {
        public class FindProductStoretInputDTO
        {
            [Required]
            public int IdStore { get; set; }
            

        }

        //DTos que mostraran los productos de x tienda 
        public class FindProductStoreOutputDTO
        {
            public int IdProduct { get; set; }

            public string  ProductName  { get; set; }
            public string  Description { get; set; }
            public int  Stock { get; set; }
            public  decimal Price { get; set; }



        }

        public class FindUserStoreInputDTO
        {
            [Required]
            public  int IdUser { get; set; }

        }

        public class FindUserStoreOutputDTO{

            public string Email { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string DateOfBrith { get; set; }
            public string Role { get; set; }
        }

        public class InfoStoreInputDTO
        {
            [Required]
            public int IdStore { get; set;}
            
        }

        public class InfoStoreOutputDTO
        { 

            public int IdUser { get; set; }
            public string Quantity { get; set; }
            public int Idproduct { get; set; }
        }
    }
}
