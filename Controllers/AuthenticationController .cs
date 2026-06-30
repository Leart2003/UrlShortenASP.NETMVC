using Microsoft.AspNetCore.Mvc;
using ShortUrl.Data.ViewModel;
using DbMenagment;
using Microsoft.EntityFrameworkCore;
using DbMenagment.Interfaces;
using Microsoft.AspNetCore.Identity;
using DbMenagment.Models;
using Shortly.Redirect.Helpers.Roles;
using Microsoft.AspNetCore.Authorization;
namespace ShortUrl.Controllers
{
    public class Authentication : Controller
    {
        private IUserInterface _userService;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManger;

        public Authentication(IUserInterface userService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManger = userManager;
        }
        [Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> LoginSubmit(LoginVm loginVm)
        {

            if (!ModelState.IsValid)
            {
                return View("Login", loginVm); 
            }
            var user =await _userManger.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null)
            {

                var passwordCheck = await _userManger.CheckPasswordAsync(user, loginVm.Password);

                if (passwordCheck)
                {
                    var userLoggedIn = await _signInManager.PasswordSignInAsync(user, loginVm.Password,false, false );
                    if (userLoggedIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt");
                        return View("Login", loginVm);
                    }
                }
            }
            return RedirectToAction("Index", "Home");

         
        }
        public async Task< IActionResult> Register(RegisterVM registerVM)
        {

            return View();
        }   
        public async Task< IActionResult>RegisterUser(RegisterVM registerVM) {

            if (!ModelState.IsValid)
            {
                return View("Register", registerVM);
            }

            var user = await _userManger.FindByEmailAsync(registerVM.emailAdress);
            if (user != null)
            {
                ModelState.AddModelError("", "User already exists!");

                return View("Register", registerVM);
            }
            

            var newUser = new AppUser()
            {
                Email = registerVM.emailAdress,
                UserName = registerVM.emailAdress,
                FullName = registerVM.fullName
            };
            var userCreate = await _userManger.CreateAsync(newUser, registerVM.password);
            if (userCreate.Succeeded)
            {
                await _userManger.AddToRoleAsync(newUser, Role.User);
                await _signInManager.PasswordSignInAsync(newUser, registerVM.password, false, false);
            }
            else
            {
                foreach (var item in userCreate.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View("Register", registerVM);
                }
            }
            return RedirectToAction("Index","Home");
        
         }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction();
        }
            
    }
}
