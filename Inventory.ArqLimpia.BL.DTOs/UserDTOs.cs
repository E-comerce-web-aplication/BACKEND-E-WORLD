using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class LoginInputDTO
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress( ErrorMessage ="Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [StringLength(8,ErrorMessage ="The password must be 5 to 32 characters long", MinimumLength =5)]
        public string Password { get; set; }

    }

    public class LoginOutputDTO{
        public bool status { get; set; }
    }

    public class FindUserInputDTO
    {
        [Required(ErrorMessage ="Id required")]
        public int Id { get; set; }
    }

    public class FindUserOutputDTO
    {
        public int Id { get; set; }
   
        public string FirstName { get; set; }
        
        public string Surname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; }
    }

    public class RegisterUserInputDTO{

        [Required(ErrorMessage ="FisrtName required")]
        [StringLength(30)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage ="Surname required")]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Id required")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress( ErrorMessage ="Invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [StringLength(8,ErrorMessage ="The password must be 5 to 32 characters long", MinimumLength =5)]
        public string Password { get; set; }

   }
    public class RegisterUserOutputDTO{

        public int Id { get; set; }
   
        public string FirstName { get; set; }
        
        public string Surname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; }
   }

}





