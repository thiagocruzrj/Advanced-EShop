using System.ComponentModel.DataAnnotations;

namespace AES.WebApp.MVC.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "The field {0} has an invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage = "The field {0} must be between {2} and {1} characteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string PasswordConfirmation { get; set; }
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "The field {0} has an invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage = "The field {0} must be between {2} and {1} characteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
