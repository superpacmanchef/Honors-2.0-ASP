using Honors_2._0.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honors_2._0.Domain.Repository
{
    public interface IUsersRepository
    {
        Task<int> CreateUser(Users user);
        Task<Users> GetUserByUserID(string UserID);
        Task<string> GetPasswordByUserID(string UserID);
        Task<Users> GetUserByEmail(string Email);
    }
}
