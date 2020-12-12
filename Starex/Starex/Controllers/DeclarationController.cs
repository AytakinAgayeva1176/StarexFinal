using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starex.Contexts;
using Starex.Interfaces;
using Starex.ViewModels;

namespace Starex.Controllers
{
    public class DeclarationController : Controller
    {
        private readonly StarexDbContext context;
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IWebHostEnvironment webHost;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #region field

        #endregion

        #region ctor
        public DeclarationController(StarexDbContext context,IDeclarationRepository declarationRepository,
                      IWebHostEnvironment webHost ,IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _declarationRepository = declarationRepository;
            this.webHost = webHost;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        public IActionResult NewDeclaration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewDeclaration(DeclarationViewModel declarationViewModel)
        {
        
            var newFileName= "";
            if (declarationViewModel.File != null)
            {
                newFileName =
             $"{Path.GetFileNameWithoutExtension(declarationViewModel.File.FileName)}" +
             $"-{DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss")}" +
             $"{Path.GetExtension(declarationViewModel.File.FileName)}";

                var rootPath = Path.Combine(webHost.WebRootPath, "images", newFileName);
                using(var fileStream = new FileStream(rootPath, FileMode.Create))
                {
                    declarationViewModel.File.CopyTo(fileStream);
                }

            }
         
            if (ModelState.IsValid)
            {
                declarationViewModel.FileName = newFileName;

                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var WarehouseId = context.Users.FirstOrDefault(x => x.Id == userId).WarehouseId;
                declarationViewModel.UserId = userId;
                declarationViewModel.WarehouseId = WarehouseId;
                declarationViewModel.DeclarationDate = DateTime.Now;
                declarationViewModel.StatusId = 1;
                declarationViewModel.TrackingCode = Guid.NewGuid().ToString().Substring(0, 8);
                var result = await _declarationRepository.Create(declarationViewModel);

                    if (result == true)
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Emeliyyat ugursuzdur!");
                    }
            }

            return View(declarationViewModel);
        }

        public async Task<IActionResult> DeleteDeclaration(int id)
        {
            await _declarationRepository.Delete(id);

            return RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Pay(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _declarationRepository.Pay(id, userId);
            if (result == true)
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
