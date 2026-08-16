using System.ComponentModel.DataAnnotations;
using Shortly.Redirect.Helpers.Validators;

namespace ShortUrl.Data.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full name is required")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [CustomEmailValidator]
        public string emailAdress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string confirmPassword { get; set; }
    }
}
