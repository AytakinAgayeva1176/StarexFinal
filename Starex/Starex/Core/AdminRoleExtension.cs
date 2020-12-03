using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Starex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Core
{
    public static class AdminRoleExtension
    {
        public async static void SeedRole(this IApplicationBuilder builder)
        {
            RoleManager<IdentityRole> role = builder.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> db = builder.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();

            if (role.Roles.Count()==0)
            {
                var result = await role.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
            }

            if (!db.Users.Any())
            {
                ApplicationUser admin = new ApplicationUser
                {
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    EmailConfirmed=true
                };

                IdentityResult identityResult = await db.CreateAsync(admin, "Admin123");
                if (identityResult.Succeeded)
                {
                    Task<IdentityResult> res = db.AddToRoleAsync(admin, "Admin");
                    res.Wait();
                }
                else
                {
                    IEnumerable<IdentityError> identityErrors = identityResult.Errors;
                }
            }
        }
    }
}
