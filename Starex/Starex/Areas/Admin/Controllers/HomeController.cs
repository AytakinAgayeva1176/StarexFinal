using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starex.Contexts;
using Starex.Models;
using Starex.ViewModels;

namespace Starex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly StarexDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(StarexDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

      
        public IActionResult Index()
        {

            return View();
        }



        public IActionResult UserList()
        {
            List<ApplicationUser> users =null;

            var rr = context.UserRoles.ToList();
            foreach (var item in rr)
            {
               users  = context.Users.Where(x=>x.Id!=item.UserId).Include(c=>c.Warehouse).ToList();
            }
            return View(users);
        }




        public IActionResult Orders()
        {
           var orders= context.Orders.ToList();
            return View(orders);
        }


    }
}
