using System.ComponentModel.DataAnnotations;


namespace Inventory.ArqLimpia.BL.DTOs
{
    //  DTOs PARA CREAR PRODUCTOS
    public class CreateProductsInputDTOs
    {  
        
        [Required(ErrorMessage = "The field Title is required")]
        [StringLength(50)]
        [MinLength(8, ErrorMessage = "The Title must have at least 8 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "The field Description is required")]
        [StringLength(150)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field Stock is required")]
        [Range(5, double.MaxValue, ErrorMessage = "The field Stock must be greater than 5.")]
        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The field Price is required")]
        [Range(10, double.MaxValue, ErrorMessage = "The field Price must be greater than 10.")]
        public decimal Price { get; set; } 

    }

    public class CreateProductsOutputDTOs
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string Description{ get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

    }

    //  DTOs PARA ELIMINAR PRODUCTOS
    public class DeleteProductsInputDTOs
    {
        [Required]
        public int IdProduct { get; set; }
    }

    public class DeleteProductsOutputDTOs
    {
        public bool IsDeleted { get; set; }
    }

    //  DTOs PARA ACTUALIZAR PRODUCTOS
    public class UpdateProductsInputDTOs
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The field Title is required")]
        [StringLength(50)]
        [MinLength(8, ErrorMessage = "The Title must have at least 8 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "The field Description is required")]
        [StringLength(150)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field Stock is required")]
        [Range(5, double.MaxValue, ErrorMessage = "The field Stock must be greater than 5.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The field Price is required")]
        [Range(10, double.MaxValue, ErrorMessage = "The field Price must be greater than 10.")]
        public decimal Price { get; set; }

    }

    public class UpdateProductsOutputDTOs
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
       
    }


    //  DTOs PARA BUSCAR PRODUCTOS
    public class FindOneProductsInputDTOs
    {
        [Required(ErrorMessage = "You must enter a title for the search")]
        public string ProductName { get; set; }
    }

    public class FindByIdDTOs {
         [Required(ErrorMessage = "You must enter a id for the search")]
        public int Id { get; set; }
      }

    public class FindOneProductsOutputDTOs
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }      

    }

     public class FindProductsOutputDTOs
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }      

    }
}
