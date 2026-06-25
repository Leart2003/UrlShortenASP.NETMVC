using Microsoft.AspNetCore.Mvc;
using ShortUrl.Data.ViewModel;
using DbMenagment;
using Microsoft.EntityFrameworkCore;
using DbMenagment.Interfaces;
namespace ShortUrl.Controllers
{
    public class Authentication : Controller
    {
        private IUserInterface _userService;
        public Authentication(IUserInterface userService)
        {
            _userService = userService;
        }
        public async Task< IActionResult> Users()
        {
             var users = await _userService.GetUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Login()
        {
         
            return View(new LoginVm());
        }
        [HttpPost]
        public async Task<IActionResult> LoginSubmit(LoginVm model)
        {

            if (!ModelState.IsValid)
            {
                return View("Login", model); 
            }
            return RedirectToAction("Index", "Home");

         
        }
        public async Task< IActionResult> Register(RegisterVM registerVM)
        {

            return View();
        }   
        public async Task< IActionResult>RegisterUser(RegisterVM registerVM) {


            return RedirectToAction("Index","Home");
        
         }
            
    }
}
