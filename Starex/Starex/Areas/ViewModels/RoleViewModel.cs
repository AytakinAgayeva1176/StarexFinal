using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewModels
{
    public class RoleViewModel : IdentityRole
    {
        public string RoleName { get; set; }
    }
}
