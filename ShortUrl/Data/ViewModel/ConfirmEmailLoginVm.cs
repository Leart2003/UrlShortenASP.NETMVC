using System.ComponentModel.DataAnnotations;
using Shortly.Redirect.Helpers.Validators;


namespace ShortUrl.Data.ViewModel
{
    public class ConfirmEmailLoginVm
    {
        [Required(ErrorMessage ="Email adress is required")]
        [CustomEmailValidator]
        public string EmailAddress { get; set; }

       
    }
}
