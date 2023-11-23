
using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class PurcharseProductsDTOs
    {
        public string Id { get; set; }
        public UserDTO User { get; set; }

        public List<ProductDTO> Products { get; set; }

        public double Total { get; set; }

        public DateTime PurchaseDate { get; set; }

        public CompanyDTO Company { get; set; }

        public string ProviderId { get; set; }

        public class UserDTO
        {
            [Required(ErrorMessage = "User ID is required.")]
            public int UserId { get; set; }
        }

        public class ProductDTO
        {
            [Required(ErrorMessage = "Product ID is required.")]
            public string IdProduct { get; set; }

            [Required(ErrorMessage = "Product price is required.")]
            public double Price { get; set; }

            [Required(ErrorMessage = "Product quantity is required.")]
            [Range(1, int.MaxValue, ErrorMessage = "Product quantity must be at least 1.")]
            public int Amount { get; set; }
        }

        public class CompanyDTO
        {
            [Required(ErrorMessage = "Company ID is required.")]
            public int CompanyId { get; set; }
        }
    }
}

