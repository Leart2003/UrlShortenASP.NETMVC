using Microsoft.AspNetCore.Mvc;
using ShortUrl.Data.ViewModel;
using DbMenagment;
using Microsoft.EntityFrameworkCore;
namespace ShortUrl.Controllers
{
    public class Authentication : Controller
    {
        private AppDbContext _appDbContext;
        public Authentication(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Users()
        {
             var user = _appDbContext
                .Users
                .Include(n => n.Urls)
                .ToList();
            return View(user);
        }

        public IActionResult Login()
        {
         
            return View(new LoginVm());
        }
        [HttpPost]
        public IActionResult LoginSubmit(LoginVm model)
        {

            if (!ModelState.IsValid)
            {
                return View("Login", model); 
            }
            return RedirectToAction("Index", "Home");

         
        }
        public IActionResult Register(RegisterVM registerVM)
        {

            return View();
        }   
        public IActionResult RegisterUser(RegisterVM registerVM) {


            return RedirectToAction("Index","Home");
        
         }
            
    }
}
