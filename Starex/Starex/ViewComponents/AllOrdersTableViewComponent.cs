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
    public class NotificationViewComponent : ViewComponent
    {
       private readonly StarexDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NotificationViewComponent(StarexDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<Order>orders)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var notifications = _context.Notifications.Where(x => x.UserId == userId).ToList();

            return await Task.FromResult((IViewComponentResult)View(notifications));
        }

 
    }


}
