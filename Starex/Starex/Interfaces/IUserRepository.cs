using Microsoft.AspNetCore.Identity;
using Starex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create(UserViewModel userViewModel);
        Task<SignInResult> Login(LoginViewModel loginViewModel);
        Task<IdentityResult> Update(SettingsViewModel viewModel);
        UserViewModel GetById(string id);
        

    }
}
