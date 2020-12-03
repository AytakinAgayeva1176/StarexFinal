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
            if (_context.UserBalances.FirstOrDefault(x=>x.UserId==userId)!=null)
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

            var products = _context.Products.Where(x => x.CountryId == id).Select(c => new SelectViewModel()
            {
                Text = c.ProductType,
                Id = c.Id
            }).ToList();

            return Json(new { items = products });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
