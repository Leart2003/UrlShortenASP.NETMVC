using DbMenagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMenagment.Interfaces
{
    public interface IUserInterface
    {

       Task<List<AppUser>> GetUsersAsync();

   
    }
}
