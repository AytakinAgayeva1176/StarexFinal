using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Starex.Contexts;
using Starex.Interfaces;
using Starex.Models;
using Starex.ViewModels;

namespace Starex.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
     
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(IOrderRepository orderRepository,
                               IHttpContextAccessor httpContextAccessor)
        {
            this.orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewOrder(OrderViewModel orderViewModel)
        {
           
            if (ModelState.IsValid)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                orderViewModel.UserId = userId;
                orderViewModel.CreationDate = DateTime.Now;
                orderViewModel.StatusId = 1;
                orderViewModel.TrackingCode = Guid.NewGuid().ToString().Substring(0,8);
                var result = await orderRepository.Create(orderViewModel);

                if (result==true)
                {
                    return Ok(new { href = "/Home/Dashboard" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Emeliyyat ugursuzdur!");
                }
               
            }

              return View(orderViewModel);
            
        }


        public async Task<IActionResult> DeleteOrder(int id)
        {
           await orderRepository.Delete(id);

            return RedirectToAction("Dashboard","Home");
        }

        public IActionResult Pay(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
             var result = orderRepository.Pay(id, userId);
            if (result==true)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                TempData["message"] = "Balansda kifayət qədər vəsait yoxdur.";
                return RedirectToAction("Dashboard", "Home");
            }

        }

    }
}
