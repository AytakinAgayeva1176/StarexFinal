using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starex.Contexts;
using Starex.ViewModels;
using Starex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewComponents
{
    public class OrderTableViewComponent : ViewComponent
    {
       private readonly StarexDbContext _context;
        public OrderTableViewComponent(StarexDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var items = await GetItemsAsync();
            return await Task.FromResult((IViewComponentResult)View(items));
        }

  
        private Task<List<Order>> GetItemsAsync()
        {
            return   _context.Orders.ToListAsync();
        }
    }


}
