using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starex.Interfaces;
using Starex.Models;

namespace Starex.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IUserBalanceRepo _userBalance;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BalanceController(IUserBalanceRepo userBalance,
                               IHttpContextAccessor httpContextAccessor)
        {
            _userBalance = userBalance;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult IncreaseBalance()
        {
            return View();
        }

        [HttpPost]

        public IActionResult IncreaseBalance(int currencyId, decimal amount)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userBalance.Increase(userId, currencyId, amount);

            return RedirectToAction("Dashboard", "Home");
        }

    }
}
