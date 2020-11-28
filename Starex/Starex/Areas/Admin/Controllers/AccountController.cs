using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Starex.Areas.ViewModels;
using Starex.Contexts;
using Starex.Models;
using Starex.ViewModels;

namespace Starex.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class AccountController : Controller
    {
        #region fields
        private readonly StarexDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        #endregion

        #region ctor
        public AccountController(StarexDbContext context, IMapper mapper,
               UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        #endregion
 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user!=null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Email ve ya şifrə yanlışdır");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Istifadəçi tapılmadı");
                }
            }


            return View(loginViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = roleViewModel.RoleName
                };

               var result= await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Emeliyyat ugursuzdur!");
                }
               
            }

            return View(roleViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateManager()
        {
            ViewBag.Roles = _context.Roles.Select(
              c => new SelectListItem()
              {
                  Text = c.Name,
                  Value = c.Id.ToString()
              }).ToList();

            return View();
        }

  

        [HttpPost]
        public async Task<IActionResult> CreateManager(ManagerRegisterViewModel manager, string RoleId)
        {
            ViewBag.Roles = _context.Roles.Select(
             c => new SelectListItem()
             {
                 Text = c.Name,
                 Value = c.Id.ToString()
             }).ToList();


            if (ModelState.IsValid)
            {
                ApplicationUser newmanager = new ApplicationUser
                {
                    Email = manager.Email,
                    UserName = manager.Email
                };

                IdentityResult identityResult = await _userManager.CreateAsync(newmanager, manager.Password);

                if (identityResult.Succeeded)
                {
                    var rolename = await _roleManager.FindByIdAsync(RoleId);
                    if (rolename!=null)
                    {
                        await _userManager.AddToRoleAsync(newmanager, rolename.Name);
                        return RedirectToAction("Index", "Home");
                    }
                      
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Role doesnt exist");
                    }
                   
                }
                else
                {
                    IEnumerable<IdentityError> identityErrors = identityResult.Errors;
                   // ModelState.AddModelError(string.Empty, identityErrors);
                
            }

            }
            return View();
        }
    }

}
