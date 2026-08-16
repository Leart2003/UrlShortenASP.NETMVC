using DbMenagment.Interfaces;
using DbMenagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMenagment.Services
{
    public class UrlService : IUrlService
    {

        private readonly AppDbContext _context;

        public UrlService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Url> AddAsync(Url url)
        {
            await _context.AddAsync(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public async Task<Url> GetByIdAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);

            return url;
        }



        public async Task<List<Url>> GetUrlAsync(string userId, bool isAdmin)
        {

            var allUrlQuery = _context
                .Urls.Include(n => n.User);
            if (isAdmin)
            {
                return await allUrlQuery.ToListAsync();
            }
            else
            {
                return await allUrlQuery.Where(n => n.UserID == userId).ToListAsync();
            }


        }



        public async Task RemoveAsync(int id)
        {
            var urls = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            if (urls is not null)
            {
                _context.Remove(urls);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Url> UpdateAsync(int id, Url url)
        {
            var urls = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            if (urls is not null)
            {
                urls.OriginalLink = url.OriginalLink;
                urls.ShortLink = url.ShortLink;
                urls.CreationDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return urls;
        }
        public async Task incrementClicks(int shortUrlId)
        {
            var dbUrl = await _context.Urls.FirstOrDefaultAsync(n => n.Id == shortUrlId);
            if (dbUrl == null)
            {
                return;
            }

            dbUrl.ClickedTime++;
            await _context.SaveChangesAsync();
        }
        public async Task<Url> GetOriginalUrl(string shortUrl)
        {
            var dbUrl = await _context.Urls.FirstOrDefaultAsync(n => n.ShortLink == shortUrl);
            return dbUrl;
        }
    }
}
