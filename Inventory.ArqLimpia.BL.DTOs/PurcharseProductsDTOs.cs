
using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class PurcharseProductsDTOs
    {
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Company ID is required.")]
        public int CompanyId { get; set; }

        public List<ProductDTO> Products { get; set; }

        [Required(ErrorMessage = "Total is required.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Provider ID is required.")]
        public string ProviderId { get; set; }


        public class ProductDTO
        {
            [Required(ErrorMessage = "Product ID is required.")]
            public string ProductId { get; set; }

            [Required(ErrorMessage = "Product quantity is required.")]
            [Range(1, int.MaxValue, ErrorMessage = "Product quantity must be at least 1.")]
            public int Quantity { get; set; }
        }

        
    }
    public class PurcharseOutputDTO{

        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public DateTime Date { get; set; }        

        public double Total { get; set; }

        public string ProviderId { get; set; }
        }
}

