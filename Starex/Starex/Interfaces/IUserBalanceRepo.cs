using Starex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Interfaces
{
    public  interface IUserBalanceRepo
    {
        void Create(UserBalance balance);
        void Increase(string userId, int currencyId ,decimal amount);
        void Decrease(string userId, int currencyId, decimal amount);

    }
}
