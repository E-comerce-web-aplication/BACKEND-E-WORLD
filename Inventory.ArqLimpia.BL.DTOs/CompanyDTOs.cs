using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL.DTOs
{

    public class CreateCompanyInputDTO
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        public string Address { get; set; }
    }

    public class CreateCompanyOutputDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        public string Address { get; set; }
    }

    public class FindOneCompanyInputDTOs
    {
        [Required(ErrorMessage = "You must enter a title for the search.")]
        public string Name { get; set; }
    }

    public class FindByIdDTO
    {
        [Required(ErrorMessage = "You must enter a id for the search")]
        public string Id { get; set; }
    }

    public class FindOneCompanyOutputDTOs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class FindCompanyOutputDTOs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

