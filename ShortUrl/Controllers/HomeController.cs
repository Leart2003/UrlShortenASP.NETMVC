using DbMenagment;
using DbMenagment.Models;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Data.ViewModel;
using System;
using System.Diagnostics;
using System.Security.Claims;


namespace ShortUrl.Controllers
{
    public class HomeController : Controller
    {



        private readonly ILogger<HomeController> _logger;
        private AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            PostUrlVm newUrl = new PostUrlVm();
            return View(newUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Remove(int linkToRemove)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShortenUrl(PostUrlVm postUrlVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", postUrlVm);
            }

            var loggedUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newUrl = new Url()
            {
                OriginalLink = postUrlVm.Url,
                ShortLink = GenerateShortUrl(8),
                ClickedTime = 0,
                UserID = loggedUserID,
                CreationDate = DateTime.UtcNow,
            };

            _appDbContext.Urls.Add(newUrl);
            await _appDbContext.SaveChangesAsync();
            TempData["Message"] = $"Your url was shortened successfully to {newUrl.ShortLink}";
            return View("Index");
        }
        private string GenerateShortUrl(int length)
        {
            Random rnd = new Random();
            const string chars = "ABCEFGHIJKLMNOPQRSTUVMWabcdefgijklmnopqrstuvmW0123456789";


            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

    }
}
