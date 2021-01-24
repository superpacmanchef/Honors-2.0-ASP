using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Persistance.Contexts;
using HonorsTest2.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Persistance.Repositories
{
    public class UserRepository : BaseRepository, IUsersRepository
    {   

        public UserRepository(Honors20Context context) : base(context)
        {          
        }

        public async Task<int> CreateUser(Users user)
        {
            await _context.Users.AddAsync(user);
            try
            {
                return await _context.SaveChangesAsync();
            } catch(Exception e)
            {
                return 0;
            }
        }

        public async Task<string> GetPasswordByUserID(string UserID)
        {
            Users user = await _context.Users.FirstAsync(u => u.UserId == UserID);
            return user.Password;
        }

        public async Task<Users> GetUserByEmail(string Email)
        {
            return await _context.Users.FirstAsync(u => u.Email == Email);
        }

        public async Task<Users> GetUserByUserID(string UserID)
        {
            return await _context.Users.FirstAsync(u => u.UserId == UserID);
        }
    }
}
