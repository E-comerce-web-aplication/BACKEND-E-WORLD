using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ProductRegisterDTOs
    {

        public class FindQueryProductRegisterDTOs
        {
            [Display(Name = "User")]
            public string? User { get; set; }

            [Display(Name = "Role")]
            public string? Role { get; set; }

            [Display(Name = "Date")]
            public DateTime? Date { get; set; }


        }
        public class FindAllProductRegisterDTOs
        {
            public string User { get; set; }
            public string Role { get; set; }
            public DateTime Date { get; set; }
            public string Product_Info { get; set; }
            public string Company_Name { get; set; }
            public string Changes { get; set; }

        }

        public class FindByIdProductRegisterDTOs
        {
            [Required(ErrorMessage = "you must enter a user id for the search")]
            public string User { get; set; }
        }


    }
}
