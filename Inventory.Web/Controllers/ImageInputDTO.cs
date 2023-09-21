using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Controllers
{
    public class ImageInputDTO  
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

        public IFormFile ImageUrl { get; set; }

        [Required(ErrorMessage = "The field Price is required")]
        [Range(10, double.MaxValue, ErrorMessage = "The field Price must be greater than 10.")]
        public decimal Price { get; set; } 

    }
}