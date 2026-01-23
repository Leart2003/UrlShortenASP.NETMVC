using DbMenagment;
using DbMenagment.Models;
using Microsoft.AspNetCore.Mvc;


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

            Url urlDb = new Url()
            {
                Id = 1,
                OriginalLink = "https://www.google.com",
                ShortLink = "SHrotl",
                ClickedTime = 1,
                UserID = 1



            };

            var allData = new List<Url>();
            allData.Add(urlDb);

            ViewData["ShortenedURL"] = "This is just short Url";
            ViewData["AllUrls"] = new List<string>() {"url 1", "Url2"};

            
            return View(allData);
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
