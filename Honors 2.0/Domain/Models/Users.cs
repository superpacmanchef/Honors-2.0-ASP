using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Honors_2._0.Domain.Models
{
    public partial class Users 
    {
        public Users() { }
        public Users(string email , string password , string firstName , string surname)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            Surname = surname;
            UserId = Guid.NewGuid().ToString();
            Orders = new HashSet<Orders>();
            Reviews = new HashSet<Reviews>();
        }

        public string UserId { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
