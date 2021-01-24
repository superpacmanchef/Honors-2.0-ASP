using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Services
{
    public interface IUserService
    {
        Task<Users> Login(string Email, string Password);
        Task<int> Register(string Email, string Password, string FirstName, string Surname);
        Task<Users> GetUserByUserID(string UserID);


    }
}
