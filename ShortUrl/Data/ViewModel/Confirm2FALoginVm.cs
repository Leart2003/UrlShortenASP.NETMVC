using System.ComponentModel.DataAnnotations;

namespace ShortUrl.Data.ViewModel
{
    public class Confirm2FALoginVm
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Verification code is required")]
        public string userConfirmationCode { get; set; }
    }
}
