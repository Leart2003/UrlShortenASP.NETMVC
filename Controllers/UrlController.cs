using AutoMapper;
using DbMenagment;
using DbMenagment.Interfaces;
using DbMenagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Data.ViewModel;


namespace ShortUrl.Controllers
{
    public class UrlController : Controller
    {

        private readonly IUrlService _urlService;
        private readonly IMapper _mapper;

        public UrlController(IUrlService urlService, IMapper mapper)
        {
            
        _urlService = urlService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var allUrls = _urlService.GetUrl();
            var mappUrl = _mapper.Map<List<Url>,List<GetUrl>>(allUrls);

            
            return View(mappUrl);
        }
        public IActionResult Remove(int id) 
        {
         _urlService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
