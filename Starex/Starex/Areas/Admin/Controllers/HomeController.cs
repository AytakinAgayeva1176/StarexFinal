using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Starex.Contexts;
using Starex.Interfaces;
using Starex.Models;
using Starex.ViewModels;

namespace Starex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin , Manager")]
    public class HomeController : Controller
    {
        private readonly StarexDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IWebHostEnvironment webHost;

        public HomeController(StarexDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,IDeclarationRepository declarationRepository,
             IOrderRepository orderRepository,IWebHostEnvironment webHost)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _declarationRepository = declarationRepository;
            _orderRepository = orderRepository;
            this.webHost = webHost;
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

        public IActionResult DeleteUser(string id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("UserList");
        }
        public IActionResult Managers()
        {
            List<ApplicationUser> managers = null;
 
            var rr = context.UserRoles.ToList();
            foreach (var item in rr)
            {
               var manager= context.Users.FirstOrDefault(x => x.Id == item.UserId);

                managers.Add(manager);
            }

            return View(managers);
        }

        public IActionResult Orders()
        {
           var orders= context.Orders.Where(x=>x.StatusId!=4).OrderByDescending(x=>x.StatusId).Include(c => c.User).Include(c => c.Status).ToList();
            return View(orders);
        }

        public IActionResult EditOrder(int id)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == id);
            order.StatusId = 3;
            context.Orders.Update(order);
            context.SaveChanges();

            return RedirectToAction("Orders"); 
        }

        [HttpPost]
        public IActionResult OrderDetails(int id)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == id);
            
            return PartialView("_OrderDetails" , order);
        }

        public IActionResult DeleteOrder(int id)
        {
            var order = context.Orders.FirstOrDefault(x => x.Id == id);
            order.StatusId = 4;
            context.Orders.Update(order);
            context.SaveChanges();

            return RedirectToAction("Orders");
        }

        public IActionResult Declarations()
        {
            var declarations = context.Declarations.OrderBy(x => x.StatusId).
                Include(c => c.User).Include(c => c.Status).ToList();
            return View(declarations);
        }

        [HttpPost]
        public IActionResult DeclarationDetails(int id)
        {
            var order = context.Declarations.FirstOrDefault(x => x.Id == id);

            return PartialView("_DeclarationDetails", order);
        }
        public IActionResult CreateDeclaration(int id)
        {
            var order= context.Orders.FirstOrDefault(x=>x.Id==id);
            var declaration = new DeclarationViewModel();
            declaration.UserId = order.UserId;
            declaration.CountryId = order.CountryId;
            declaration.Quantity=order.Quantity;
            declaration.WarehouseId = context.Users.FirstOrDefault(x => x.Id == order.UserId).WarehouseId;

            var products = context.Products.Where(x => x.CountryId == 1).Select(c => new SelectListItem()
            {
                Text = c.ProductType,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Currency = "USD";
            if (order.CountryId == 2)
            {
                ViewBag.Currency = "TL";
                products = context.Products.Where(x => x.CountryId == 2).Select(c => new SelectListItem()
                {
                    Text = c.ProductType,
                    Value = c.Id.ToString()
                }).ToList();
            }

           ViewBag.Products = products;
            _orderRepository.Delete(order.Id);
            return View(declaration);
        }

        [HttpPost]
 
        public async Task<IActionResult> CreateDeclaration(DeclarationViewModel declarationViewModel)
        {

            var newFileName = "";
            if (declarationViewModel.File != null)
            {
                newFileName =
             $"{Path.GetFileNameWithoutExtension(declarationViewModel.File.FileName)}" +
             $"-{DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss")}" +
             $"{Path.GetExtension(declarationViewModel.File.FileName)}";

                var rootPath = Path.Combine(webHost.WebRootPath, "images", newFileName);
                using (var fileStream = new FileStream(rootPath, FileMode.Create))
                {
                    declarationViewModel.File.CopyTo(fileStream);
                }

            }

            if (ModelState.IsValid)
            {
                declarationViewModel.FileName = newFileName;
                declarationViewModel.DeclarationDate = DateTime.Now;
                declarationViewModel.StatusId = 1;
                declarationViewModel.TrackingCode = Guid.NewGuid().ToString().Substring(0, 8);
                var result = await _declarationRepository.Create(declarationViewModel);

                if (result == true)
                {
                    return RedirectToAction("Orders", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Emeliyyat ugursuzdur!");
                }
            }

            return View(declarationViewModel);

           }


        public IActionResult EditDeclaration(int id)
        {
            var declaration = context.Declarations.FirstOrDefault(x => x.Id == id);
            ViewBag.StatusId = context.DeclarationStatuses.Select(
               c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               }).ToList();

            return View(declaration);
        }

       
        [HttpPost]
        public IActionResult EditDeclaration(Declaration declaration)
        {
            ViewBag.StatusId = context.DeclarationStatuses.Select(
               c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               }).ToList();

                context.Declarations.Update(declaration);
                context.SaveChanges();
                return RedirectToAction("Declarations");
             //declaration.StatusId = id;

        }

       

    }
}
