using Microsoft.AspNetCore.Mvc;

namespace ShortUrl.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
