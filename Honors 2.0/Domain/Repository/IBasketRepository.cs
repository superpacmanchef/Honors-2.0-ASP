using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honors_2._0.Domain.Models;

namespace Honors_2._0.Domain.Repository
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketByUserID(string UserID);
        Task<int> CreateBasket(Users User);
        Task<string> GetBasketIDByUserID(string UserID);
       
    }
}
