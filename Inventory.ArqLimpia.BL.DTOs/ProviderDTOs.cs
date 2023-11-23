using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ProviderDTOs
    {
        [Required(ErrorMessage = "The field ProviderName is required")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "The ProviderName must have at least 8 characters.")]
        public string ProviderName { get; set; }

        [Required(ErrorMessage = "The field Description is required")]
        [StringLength(150)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field Contact is required")]
        [StringLength(50)]
        public string Contact { get; set; }

        [Required(ErrorMessage = "The field Email is required")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field Address is required")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "The field PostalCode is required")]
        [StringLength(50)]
        public string PostalCode { get; set; }
    }
}
