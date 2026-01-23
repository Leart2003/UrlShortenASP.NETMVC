using DbMenagment;
using DbMenagment.Models;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Data.ViewModel;
using System;
using System.Diagnostics;


namespace ShortUrl.Controllers
{
    public class HomeController : Controller
    {

       

        private readonly ILogger<HomeController> _logger;
        private AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext )
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            PostUrlVm newUrl =  new PostUrlVm();
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

        public IActionResult ShortenUrl(PostUrlVm postUrlVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", postUrlVm);
            };
            Url newUrl = new Url()
            {
                OriginalLink = postUrlVm.Url,
                ShortLink = GenerateShortUrl(600),
                ClickedTime = 0,
                UserID = null, 
                CreationDate = DateTime.Now,

               
            };
            _appDbContext.Urls.Add(newUrl);
            _appDbContext.SaveChanges();
            TempData["Message"] = $"Your url was shorten succesfully to {newUrl.ShortLink}";
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
