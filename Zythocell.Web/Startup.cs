using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Zythocell.Identity;
using Zythocell.DAL.Context;
using Zythocell.Common.Interfaces;
using Zythocell.Common.Interfaces.IUsesCases;
using Zythocell.DAL;
using Zythocell.BLL.UsesCases;

namespace Zythocell.Web
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
            services.AddDbContext<ZythocellContext>(options =>
                options.UseSqlite(@"Data Source = C:\Users\Thomas\source\repos\Zythocell\Services\Cellar\Zythocell.DAL\ZythocellCellarDb.db"));

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(@"Data Source = C:\Users\Thomas\source\repos\Zythocell\Services\Identity\Zythocell.Identity\ZythocellIdentityDb.db"));

            services.AddTransient<CellarSeeder>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICellarUsesCases, CellarUsesCases>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddIdentity<AppUser, AppUserRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
                    .AddRoleManager<RoleManager<AppUserRole>>()
                    .AddUserManager<UserManager<AppUser>>()
                    .AddSignInManager()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cellar}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
