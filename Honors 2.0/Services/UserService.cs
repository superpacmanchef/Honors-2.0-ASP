using Honors_2._0.Domain.Models;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Honors_2._0.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public async Task<Users> Login(string Email, string Password)
        {
            Users user = await _usersRepository.GetUserByEmail(Email);
            if (!BC.Verify(Password, user.Password))
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<int> Register(string Email, string Password, string FirstName, string Surname)
        {
            string HashedPassword = BC.HashPassword(Password);
            Users user = new Users(Email, HashedPassword, FirstName, Surname);
            return await _usersRepository.CreateUser(user);

        }

        public async Task<Users> GetUserByUserID(string UserID)
        {
            return await _usersRepository.GetUserByUserID(UserID);
        }
    }
}
