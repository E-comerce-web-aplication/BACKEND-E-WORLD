using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class Store
    {
        public class CreateStoreInputDTOs
        {  

            [Required(ErrorMessage = "The Name field is required.")]
            public string Name { get; set; }

            [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
            public string Description { get; set; }

            [Required(ErrorMessage = "The Email field is required.")]
            [EmailAddress(ErrorMessage = "The Email field must be a valid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The PostalCode field is required.")]
            public string PostalCode { get; set; }

            [Required(ErrorMessage = "The Department field is required.")]
            public string Department { get; set; }

            [Required(ErrorMessage = "The City field is required.")]
            public string City { get; set; }

            [Required(ErrorMessage = "The Address field is required.")]
            public string Address { get; set; }
        }


        public class CreateStoreOutputDTOs
        {
            public string Id { get; set; }

            [Required(ErrorMessage = "The Name field is required.")]
            public string Name { get; set; }

            [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
            public string Description { get; set; }

            [Required(ErrorMessage = "The Email field is required.")]
            [EmailAddress(ErrorMessage = "The Email field must be a valid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The PostalCode field is required.")]
            public string PostalCode { get; set; }

            [Required(ErrorMessage = "The Department field is required.")]
            public string Department { get; set; }

            [Required(ErrorMessage = "The City field is required.")]
            public string City { get; set; }

            [Required(ErrorMessage = "The Address field is required.")]
            public string Address { get; set; }
        }

        public class FindOneStoreInputDTOs
        {
            [Required(ErrorMessage = "You must enter a title for the search.")]
            public string Name { get; set; }
        }

        public class FindByIdDTOs
        {
            [Required(ErrorMessage = "You must enter a id for the search")]
            public string Id { get; set; }
        }

        public class FindOneStoreOutputDTOs
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
            public string PostalCode { get; set; }
            public string Department { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
        }

        public class FindStoreOuputDTOs
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
            public string PostalCode { get; set; }
            public string Department { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
        }
    }
}