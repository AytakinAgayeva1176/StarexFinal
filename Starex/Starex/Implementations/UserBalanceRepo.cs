using Starex.Contexts;
using Starex.Interfaces;
using Starex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Implementations
{
    public class UserBalanceRepo : IUserBalanceRepo
    {
        private readonly StarexDbContext _context;

        public UserBalanceRepo(StarexDbContext context)
        {
            _context = context;
        }

        public void Create(UserBalance balance)
        {
          _context.UserBalances.Add(balance);
            _context.SaveChanges();
        
        }

        public void Increase(string userId,int currencyId, decimal amount)
        {
            var userbalance= _context.UserBalances.FirstOrDefault(x => x.UserId == userId && x.CurrencyId==currencyId);
            if (userbalance!=null)
            {
                userbalance.Balance += amount;
                _context.UserBalances.Update(userbalance);
                _context.SaveChanges();
            }
           
        }

        public void Decrease(decimal amount)
        {
            throw new NotImplementedException();
        }

     
    }
}
