using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Inventory.ArqLimpia.BL.DTOs
{
    // DTOs PARA CREAR PROVEEDORES
    public class CreateProviderInputDTOs
    {
        [Required(ErrorMessage = "ProviderName is required")]
        [StringLength(200, ErrorMessage = "ProviderName cannot exceed 200 characters")]
        public string ProviderName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [StringLength(20, ErrorMessage = "Contact cannot exceed 20 characters")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "PostalCode is required")]
        [StringLength(20, ErrorMessage = "PostalCode cannot exceed 20 characters")]
        public string PostalCode { get; set; }
    }

    public class CreateProviderOutputDTOs
    {
        public string IdProvider { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }

    // DTOs PARA ELIMINAR PROVEEDORES
    public class DeleteProviderInputDTOs
    {
        [Required(ErrorMessage = "The field IdProvider is required")]
        public string IdProvider { get; set; }
    }

    public class DeleteProviderOutputDTOs
    {
        public bool IsDeleted { get; set; }
    }

    // DTOs PARA ACTUALIZAR PROVEEDORES
    public class UpdateProviderInputDTOs
    {
        public string IdProvider { get; set; }
        [Required(ErrorMessage = "ProviderName is required")]
        [StringLength(200, ErrorMessage = "ProviderName cannot exceed 200 characters")]
        public string ProviderName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [StringLength(20, ErrorMessage = "Contact cannot exceed 20 characters")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "PostalCode is required")]
        [StringLength(20, ErrorMessage = "PostalCode cannot exceed 20 characters")]
        public string PostalCode { get; set; }
    }

    public class UpdateProviderOutputDTOs
    {
        public string IdProvider { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }

    // DTOs PARA BUSCAR PROVEEDORES
    public class FindOneProviderInputDTOs
    {
        [Required(ErrorMessage = "You must enter a provider name for the search")]
        public string ProviderName { get; set; }
    }

    public class FindOneProviderOutputDTOs
    {
        public string IdProvider { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
    public class FindProviderOutputDTOs
    {
        public string IdProvider { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }

    // DTO para buscar por ID
    public class FindByIdProviderDTOs
    {
        [Required(ErrorMessage = "You must enter an ID for the search")]
        public string IdProvider { get; set; }
    }


    public class FindByIdProviderOutputDTOs
    {
        public string IdProvider { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
