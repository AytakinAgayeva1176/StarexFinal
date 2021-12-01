using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Starex.Areas.ViewModels;
using Starex.Contexts;
using Starex.Core;
using Starex.Implementations;
using Starex.Interfaces;
using Starex.Models;
using Starex.Models.Email;
using Starex.ViewModels;

namespace Starex
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserViewModelProfile());
                mc.AddProfile(new OrderViewModelProfile());
                mc.AddProfile(new DeclarationViewModelProfile());
                mc.AddProfile(new SettingsViewModelProfile());
            });
            #region Email configuration
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            #endregion
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContext<StarexDbContext>(
                x => x.UseSqlServer(@"Server=FNCT-178;Database=StarexDb;Trusted_Connection=True;"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddIdentity<ApplicationUser, IdentityRole>(
                option =>
                {
                    option.Password.RequireUppercase = false;
                    option.Password.RequireNonAlphanumeric = false;


                }).AddEntityFrameworkStores<StarexDbContext>().AddDefaultTokenProviders(); ;

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDeclarationRepository, DeclarationRepository>();
            services.AddScoped<IUserBalanceRepo, UserBalanceRepo>();

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = new PathString("/Admin/Account/Login");
                option.AccessDeniedPath = new PathString("/Admin/Home/Index");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.SeedRole();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //      name: "areas",
            //      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
