using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Starex.Contexts;
using Starex.Interfaces;
using Starex.Models;
using Starex.ViewModels;

namespace Starex.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StarexDbContext _context;
        private readonly IMapper mapper;

        public OrderRepository(StarexDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<bool> Create(OrderViewModel orderViewModel)
        {
            var order = mapper.Map<Order>(orderViewModel);
            await _context.Orders.AddAsync(order);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;

        }

        public bool Pay(int id, string userId)
        {
            var currencyId=0;
            var order = _context.Orders.Find(id);
            if (order.CountryId == 2)
            {
                currencyId = 2;
            }
            else
            {
                currencyId = 1;
            }
           var result=false;
           var userbalance= _context.UserBalances.FirstOrDefault(x => x.UserId == userId && x.CurrencyId == currencyId);
            var balance = userbalance.Balance;
            var amount = order.PriceResult;
            if (order.StatusId==1)
            {
                if (amount <= balance)
                {
                    order.StatusId = 2;
                    _context.Orders.Update(order);
                    userbalance.Balance = balance - amount;
                    _context.UserBalances.Update(userbalance);
                    _context.SaveChanges();

                    result = true;


                }
            }
           
            return result;
        }
    }
}
