using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Starex.Contexts;
using Starex.Core;
using Starex.Interfaces;
using Starex.Models;
using Starex.Models.Email;
using Starex.ViewModels;


namespace Starex.Controllers
{
    public class AccountController : Controller
    {

        #region fields
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly StarexDbContext _dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly Starex.Models.Email.IEmailService _mailService;
        #endregion
        #region ctor
        public AccountController(StarexDbContext dbContext, IMapper mapper,
               UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
               IUserRepository userRepository, RoleManager<IdentityRole> roleManager,
              Starex.Models.Email.IEmailService mailService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _userRepository = userRepository;
            _roleManager = roleManager;
            ViewBag.Warehouse = _dbContext.Warehouses.Select(
                c => new SelectListItem()
                {
                    Text = c.Address,
                    Value = c.Id.ToString()
                }).ToList();
            _mailService = mailService;

        }
        #endregion


        public IActionResult Register()
        {
            ViewBag.Warehouse = _dbContext.Warehouses.Select(
                c => new SelectListItem()
                {
                    Text = c.Address,
                    Value = c.Id.ToString()
                }).ToList();

            return View();      
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            ViewBag.Warehouse = _dbContext.Warehouses.Select(
                c => new SelectListItem()
                {
                    Text = c.Address,
                    Value = c.Id.ToString()
                }).ToList();

            if (ModelState.IsValid)
             {
                var result =  await _userRepository.Create(userViewModel);

                if (result.Succeeded)
                {
                    LoginViewModel loginViewModel = new LoginViewModel()
                    {
                        Email = userViewModel.Email,
                        Password=userViewModel.Password
                    };
                   
                    await _userRepository.Login(loginViewModel);
                    var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Email==userViewModel.Email);
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var emailConfrimationLink = Url.Action("EmailConfrimation", "Account", null, Request.Scheme);
                    MailRequest mailRequest = new MailRequest
                    {
                        ToEmail = userViewModel.Email,
                        Subject = "Email Confrimation",
                        Body = "<form action='"+ emailConfrimationLink + "'>" +
                        "<input name='Token' value='" + token + "' type='hidden'/>" +
                        "<input name='Email' value='" + user.Email + "' type='hidden'/>" +
                        "<input type='submit' value='EmailConfrimation'/></form>"
                    };

                    await _mailService.SendEmailAsync(mailRequest);

                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Emeliyyat ugursuzdur!");
                 }

            }
                   return View(userViewModel);
        }



        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                await signInManager.SignOutAsync();
                var result = await _userRepository.Login(loginViewModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Home");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Ugursuz emeliyyat");
                }

            }
            return View(loginViewModel);
        }


  
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            
            return RedirectToAction("Login", "Account");
        }



        public IActionResult Settings(string id)
        {
            ViewBag.Warehouse = _dbContext.Warehouses.Select(
              c => new SelectListItem()
              {
                  Text = c.Address,
                  Value = c.Id.ToString()
              }).ToList();

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            SettingsViewModel settingsViewModel = new SettingsViewModel();
            settingsViewModel = _mapper.Map<SettingsViewModel>(user);
            return View(settingsViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Settings(SettingsViewModel viewModel)
        {
            ViewBag.Warehouse = _dbContext.Warehouses.Select(
              c => new SelectListItem()
              {
                  Text = c.Address,
                  Value = c.Id.ToString()
              }).ToList();

            if (ModelState.IsValid)
            {
                var result = await _userRepository.Update(viewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Ugursuz emeliyyat");
                }

            }
            return View(viewModel);
        }

    }
}
