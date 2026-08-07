using AutoMapper;
using DbMenagment;
using DbMenagment.Interfaces;
using DbMenagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly.Redirect.Helpers.Roles;
using ShortUrl.Data.ViewModel;
using System.Security.Claims;


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

        [Authorize(Roles ="Admin")]
        public async Task< IActionResult> Index()

        {
            var loggedUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Role.Admin);
            var allUrls = await _urlService.GetUrlAsync(loggedUserID, isAdmin);
            var mappUrl = _mapper.Map<List<Url>,List<GetUrl>>(allUrls);

            
            return View(mappUrl);
        }
        public async Task<IActionResult> Remove(int id) 
        {
         await _urlService.RemoveAsync(id);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Create(int id)
        {
       

            return RedirectToAction("Index");

        }
    }
}
