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

        public OrderRepository(StarexDbContext context,IMapper mapper)
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

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
