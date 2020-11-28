using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Starex.ViewModels;

namespace Starex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

      
        public IActionResult Index()
        {

            return View();
        }


     
      
    }
}
