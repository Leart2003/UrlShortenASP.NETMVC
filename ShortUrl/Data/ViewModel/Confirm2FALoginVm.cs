using System.ComponentModel.DataAnnotations;
using Shortly.Redirect.Helpers.Validators;


namespace ShortUrl.Data.ViewModel
{
    public class Confirm2FALoginVm
    {
       
        public string UserId { get; set; }

        public string userConfirmationCode { get; set; }


    }
}
