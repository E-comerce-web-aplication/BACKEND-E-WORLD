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
            [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de la empresa debe tener entre 3 y 100 caracteres")]
            public string Name { get; set; }

            [StringLength(250, ErrorMessage = "La descripción de la empresa no puede exceder los 250 caracteres")]
            public string Description { get; set; }

            [Required(ErrorMessage = "El correo electrónico es obligatorio")]
            [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
            public string Email { get; set; }

            [StringLength(200, ErrorMessage = "La dirección de la empresa no puede exceder los 200 caracteres")]
            public string Address { get; set; }
        }

        public class CreateCompanyOutputDTO
        {
            public int CompanyId { get; set; }
            public string Message { get; set; }
        }

        public class DeleteCompanyInputDTO
        {
            [Required(ErrorMessage = "El nombre de la empresa a eliminar es obligatorio")]
            public string Name { get; set; }
        }

        public class DeleteCompanyOutputDTO
        {
            public string Message { get; set; }
        }

        public class UpdateCompanyInputDTO
        {
            [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre de la empresa debe tener entre 3 y 100 caracteres")]
            public string Name { get; set; }

            [StringLength(250, ErrorMessage = "La descripción de la empresa no puede exceder los 250 caracteres")]
            public string Description { get; set; }

            [Required(ErrorMessage = "El correo electrónico es obligatorio")]
            [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
            public string Email { get; set; }

            [StringLength(200, ErrorMessage = "La dirección de la empresa no puede exceder los 200 caracteres")]
            public string Address { get; set; }
        }

        public class UpdateCompanyOutputDTO
        {
            public string Message { get; set; }
            public bool Success { get; set; }
        }
    }

