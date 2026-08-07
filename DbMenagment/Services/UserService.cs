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
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> AddAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

    

   

        public async Task<List<AppUser>> GetUsersAsync()
        {
            var users =await _context.Users.Include(n => n.Urls).ToListAsync();
            return users;
        }

       

     
    }
}
