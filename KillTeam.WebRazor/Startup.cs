using KillTeam.WebRazor.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillTeam.WebRazor.Services;
using TheCoderForge.Identity;

namespace KillTeam.WebRazor
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                    // ass the DbContext is not in the webrazor app, we must change the assembly used for migrations:
                  , b=> b.MigrationsAssembly("KillTeam.WebRazor")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options =>
                                                         {
                                                             options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                                                             options.User.RequireUniqueEmail = true;// default password setting for identity
                                                             options.Password.RequiredLength = 6;// default password setting for identity
                                                             options.Password.RequireDigit = true;// default password setting for identity
                                                             options.Password.RequireLowercase = true;// default password setting for identity
                                                             options.Password.RequireUppercase = true;// default password setting for identity
                                                             options.Password.RequireNonAlphanumeric = true;// default password setting for identity
                                                             options.Password.RequiredUniqueChars = 1;// default password setting for identity
                                                             options.SignIn.RequireConfirmedEmail = true;// default password setting for identity
                                                             //, options.SignIn.RequireConfirmedAccount = true;
                                                             //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                                                             //options.Lockout.MaxFailedAccessAttempts = 5;
                                                             //options.Lockout.AllowedForNewUsers = true;
                                                         })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
                 

            services.AddRazorPages();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


            DataSeeder.Initialise(serviceProvider); 

        }
    }
}
