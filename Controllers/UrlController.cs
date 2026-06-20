using DbMenagment;
using DbMenagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Data.ViewModel;


namespace ShortUrl.Controllers
{
    public class UrlController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _appDbContext;

        public UrlController( AppDbContext appDbContext)
        {
            
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            var allUrls = _appDbContext.Urls
                .Include(n => n.User)
                .Select(url => new GetUrl()
            
                {
                Id = url.Id,
                OriginalLink = url.OriginalLink,
                ShortLink = url.ShortLink,
                ClickedTime = url.ClickedTime,
                UserID = url.User.Id,
                User = new GetUserVM() 
                {
                    Id = url.User.Id,
                    FullName = url.User.email,
                }



            }).ToList();

        

            
            return View(allUrls);
        }
        public IActionResult Remove(int id, int userId) 
        {
            var url = _appDbContext.Urls.FirstOrDefault(n => n.Id == id);
            _appDbContext.Urls.Remove(url);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
