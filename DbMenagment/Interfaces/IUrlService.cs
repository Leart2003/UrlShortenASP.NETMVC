using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMenagment.Models;

namespace DbMenagment.Interfaces
{
    public interface IUrlService 
    {

      Task<  List<Url>> GetUrlAsync(string userId, bool isAdmin);

        Task<Url> AddAsync(Url url);

        Task<Url> GetByIdAsync(int id);

        Task<Url> UpdateAsync(int id, Url url);


        Task RemoveAsync(int id);

      Task<  Url> GetOriginalUrl(string shortUrl);

       Task  incrementClicks(int shortUrlId);

    }
}
