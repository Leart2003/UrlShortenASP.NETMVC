using System.ComponentModel.DataAnnotations;

namespace ShortUrl.Data.ViewModel
{
    public class PostUrlVm
    {
        [Required(ErrorMessage = "The url is required")]
        [RegularExpression("", ErrorMessage = "This is not  a valid URL")]
        public string Url { get; set; }
    }
}
