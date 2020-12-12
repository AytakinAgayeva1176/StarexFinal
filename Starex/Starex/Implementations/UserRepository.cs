using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starex.Contexts;
using Starex.Interfaces;
using Starex.Models;
using Starex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Implementations
{
    public class UserRepository : IUserRepository
    {
        #region fields
        private readonly StarexDbContext _starexDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserBalanceRepo _userBalance;
        #endregion

        #region ctor
        public UserRepository(StarexDbContext starexDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
               IUserBalanceRepo userBalance)
        {
            _starexDbContext = starexDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _userBalance = userBalance;
        }
        #endregion
        public async Task<IdentityResult> Create(UserViewModel userViewModel)
        {
            var user = _mapper.Map<ApplicationUser>(userViewModel);
            user.UserName = userViewModel.Email;
            user.UserCode = Guid.NewGuid().ToString().Substring(0, 6);

            var result = await _userManager.CreateAsync(user, userViewModel.Password);

            UserBalance balanceTRY = new UserBalance()
            {
                CurrencyId = 2,
                Balance = 0,
                UserId = user.Id
            };
            UserBalance balanceUSD = new UserBalance()
            {
                CurrencyId = 1,
                Balance = 0,
                UserId = user.Id
            };

            _userBalance.Create(balanceTRY);
            _userBalance.Create(balanceUSD);

            return result;
             }

        public UserViewModel GetById(string id)
        {
            var user = _starexDbContext.Users.Find(id);
            return (UserViewModel)Convert.ChangeType(user, typeof(UserViewModel));
        }


        public async Task<SignInResult> Login(LoginViewModel loginViewModel)
        {     
            var signInResult = await _signInManager.PasswordSignInAsync(
                loginViewModel.Email, loginViewModel.Password,false,false);
         
           
            return signInResult;
        }


        public async Task<IdentityResult> Update(SettingsViewModel viewModel)
        {
            var _muser = _starexDbContext.Users.FirstOrDefault(x => x.Id == viewModel.Id);
           var user = _mapper.Map(viewModel, _muser);
            user.UserName = viewModel.Email;
            var newPassword = _userManager.PasswordHasher.HashPassword(user, viewModel.Password);
            user.PasswordHash = newPassword;
           
            var result = await _userManager.UpdateAsync(user);


            return result;
        }
    }
}
