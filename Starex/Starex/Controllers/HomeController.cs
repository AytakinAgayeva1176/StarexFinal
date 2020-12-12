using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Starex.Contexts;
using Starex.Models;
using Starex.ViewModels;

namespace Starex.Controllers
{
    public class HomeController : Controller
    {
        #region fields
        private readonly ILogger<HomeController> _logger;
        private readonly StarexDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region ctor
        public HomeController(ILogger<HomeController> logger, StarexDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tariff()
        {
            return View();
        }

        public IActionResult Tranportation()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId!=null)
            {
                var allOrders = _context.Orders.Where(x => x.UserId == userId).ToList();
                var unpaidOrders = _context.Orders.Where(x => x.UserId == userId && x.StatusId == 1).ToList();
                var paidOrders = _context.Orders.Where(x => x.UserId == userId && x.StatusId == 2).ToList();
                var orderedOrders = _context.Orders.Where(x => x.UserId == userId && x.StatusId == 3).ToList();
                var deletedOrders = _context.Orders.Where(x => x.UserId == userId && x.StatusId == 4).ToList();
                ViewBag.AllOrders = allOrders.Count();
                ViewBag.UnpaidOrders = unpaidOrders.Count();
                ViewBag.PaidOrders = paidOrders.Count();
                ViewBag.OrderedOrders = orderedOrders.Count();
                ViewBag.DeletedOrders = deletedOrders.Count();

                var allDeclarations = _context.Declarations.Where(x => x.UserId == userId).ToList();
                var declaredDeclarations = _context.Declarations.Where(x => x.UserId == userId && x.StatusId == 1).ToList();
                var inForeignWarehouseDeclarations = _context.Declarations.Where(x => x.UserId == userId && x.StatusId == 2).ToList();
                var onTheWayDeclarations = _context.Declarations.Where(x => x.UserId == userId && x.StatusId == 3).ToList();
                var inLocalWarehouseDeclarations = _context.Declarations.Where(x => x.UserId == userId && x.StatusId == 4).ToList();
                var deliveredDeclarations = _context.Declarations.Where(x => x.UserId == userId && x.StatusId == 5).ToList();
                ViewBag.allDeclarations = allDeclarations.Count();
                ViewBag.declaredDeclarations = declaredDeclarations.Count();
                ViewBag.inForeignWarehouseDeclarations = inForeignWarehouseDeclarations.Count();
                ViewBag.onTheWayDeclarations = onTheWayDeclarations.Count();
                ViewBag.inLocalWarehouseDeclarations = inLocalWarehouseDeclarations.Count();
                ViewBag.deliveredDeclarations = deliveredDeclarations.Count();
            }
           
            if (_context.UserBalances.FirstOrDefault(x => x.UserId == userId) != null)
            {
                var balanceTRY = _context.UserBalances.FirstOrDefault(x => x.UserId == userId && x.CurrencyId == 2).Balance.ToString();
                var balanceUSD = _context.UserBalances.FirstOrDefault(x => x.UserId == userId && x.CurrencyId == 1).Balance.ToString();
                ViewBag.balanceTRY = balanceTRY;
                ViewBag.balanceUSD = balanceUSD;
            }
            return View();
        }



        [HttpPost]
        public JsonResult GetAllProductWithId(int id)
        {
            if (id == 0) return new JsonResult(BadRequest());

            var products = _context.Products.Where(x => x.CountryId == 1).Select(c => new SelectViewModel()
            {
                Text = c.ProductType,
                Id = c.Id
            }).ToList();

            if (id==2)
            {
                products = _context.Products.Where(x => x.CountryId == id).Select(c => new SelectViewModel()
                {
                    Text = c.ProductType,
                    Id = c.Id
                }).ToList();
            }
           

            return Json(new { items = products });
        }

        [HttpPost]
        public async Task<PartialViewResult> GetAllOrdersWithStatusId(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orders = new List<Order>();

            if (id == 0)
            {
                orders = await _context.Orders.Where(x => x.UserId == userId).ToListAsync();
            }
            else
            {
                orders = await _context.Orders.Where(x => x.UserId == userId && x.StatusId == id).ToListAsync();
            }


            return PartialView("_OrderList", orders);

        }

        [HttpPost]
        public async Task<PartialViewResult> GetAllDeclarationsWithStatusId(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var declarations = new List<Declaration>();

            if (id == 0)
            {
                declarations = await _context.Declarations.Where(x => x.UserId == userId).ToListAsync();
            }
            else
            {
                declarations = await _context.Declarations.Where(x => x.UserId == userId && x.StatusId == id).ToListAsync();
            }


            return PartialView("_DeclarationsList", declarations);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
