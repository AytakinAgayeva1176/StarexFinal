using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starex.Contexts;
using Starex.ViewModels;
using Starex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Starex.ViewComponents
{
    public class AllOrdersTableViewComponent : ViewComponent
    {
       private readonly StarexDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AllOrdersTableViewComponent(StarexDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<Order>orders)
        {

          //  var items = await GetItemsAsync(id);
            return await Task.FromResult((IViewComponentResult)View(orders));
        }

  
        private Task<List<Order>> GetItemsAsync(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id==0)
            {
                return _context.Orders.Where(x => x.UserId == userId).ToListAsync();
            }
            return _context.Orders.Where(x => x.UserId == userId && x.StatusId==id).ToListAsync();

        }
    }


}
