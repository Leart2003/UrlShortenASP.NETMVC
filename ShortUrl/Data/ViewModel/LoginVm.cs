using System.ComponentModel.DataAnnotations;
using Shortly.Redirect.Helpers.Validators;


namespace ShortUrl.Data.ViewModel
{
    public class LoginVm
    {
        [Required(ErrorMessage ="Email adress is required")]
        [CustomEmailValidator]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Password is requried")]
        [MinLength(8, ErrorMessage =("Password must be atleast 8 characters"))]
        public string Password { get; set; } = string.Empty;
    }
}
