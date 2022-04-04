using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheCoderForge.Identity;

namespace TheCoderForge.Identity
{
    public static class DataSeeder
    {

        /// <summary>Seeds the database with required data</summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <summary>To use call inside a .net core website using identity.
        /// in the Startup class, at teh end of the Configure() method:
        /// <code>TheCoderForge.Identity.DataSeeder.Initialise(app.ApplicationServices);</code>
        /// </summary>
        public static void Initialise(IServiceProvider serviceProvider)
        {

                var context = serviceProvider.GetService<ApplicationDbContext>();

                if (context == null)
                {
                    Debugger.Break();
                    throw new Exception("Database Context is null");
                }

                string[] roleArray = Enum.GetNames(typeof(UserRolesEnum));
                CreateRoles(context, roleArray);

                var user = new ApplicationUser
                {
                    Email = "smith.johnpaul@gmail.com",
                    NormalizedEmail = "SMITH.JOHNPAUL@GMAIL.COM",
                    UserName = "Lobo",
                 NormalizedUserName = "LOBO",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };


                CreateUser(serviceProvider, context, user, roleArray ,"The2Towers");

                context.SaveChanges();

        }


        /// <summary>
        /// Creates the IdentityRoles for the application
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        /// <param name="roleNames">The role names.</param>
        private static void CreateRoles(ApplicationDbContext databaseContext,  string[] roleNames)
        {
            foreach (string roleName in roleNames)
            {


                var roleStore = new RoleStore<IdentityRole>(databaseContext);

                if (!databaseContext.Roles.Any(r => r.Name == roleName))
                {
                    var newRole = new IdentityRole(roleName);
                    newRole.NormalizedName = roleName.ToUpper();

                    roleStore.CreateAsync(newRole).Wait();
                }
            }
        }

        /// <summary>Creates the default ApplicationUsers</summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="context">The context.</param>
        /// <param name="user">The user.</param>
        /// <param name="roles">The roles.</param>
        /// <remarks>Must be called after the IdentityRoles have been created.</remarks>
        private static void CreateUser(IServiceProvider serviceProvider, ApplicationDbContext context, ApplicationUser user, string[] roles, string password)
        {

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                // user does not exist, so create it
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                var hashed = passwordHasher.HashPassword(user, password);
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                 userStore.CreateAsync(user).Wait( ) ;
            }
            
      
            
            AssignUserRoles(serviceProvider, user.Email,  roles).Wait();

         }

        public static void SetUserPassword(ApplicationDbContext context,ApplicationUser user, string password)
        {
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                var hashed = passwordHasher.HashPassword(user,password);
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(user);

            }
        }/// <summary>Assigns the Identity Roles to default ApplicationUsers.</summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="userEmail">The email.</param>
        /// <param name="roles">The roles.</param>
        public static async Task<IdentityResult> AssignUserRoles(IServiceProvider serviceProvider,string userEmail, string[] roles)
        {
            // use the Microsoft.Extension.DependencyInjection.ServiceProviderServiceExtensions.Creation
            // extension method to resolve the scoped ApplicationDbContext from the service provider 
           // using (var serviceScope = serviceProvider.CreateScope()) // 
            //{

                var  userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            

                var user = await userManager.FindByEmailAsync(userEmail);


                try
                {
                    var rolesBeforeXXX = userManager.GetRolesAsync(user).Result;
                }
                catch (Exception e)
                {
                    Debugger.Break();

                }

                var rolesBefore = userManager.GetRolesAsync(user).Result;
                var result = await userManager.AddToRolesAsync(user, roles);


                var rolesAfter = userManager.GetRolesAsync(user).Result;
                return result;

        }









        ///// <summary>Assigns the Identity Roles to default ApplicationUsers.</summary>
        ///// <param name="serviceProvider">The service provider.</param>
        ///// <param name="email">The email.</param>
        ///// <param name="roles">The roles.</param>
        //protected static async Task<IdentityResult>  AssignUserRoles(IServiceProvider serviceProvider, string email, string[] roles)
        //{




        //    UserManager<ApplicationUser> _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
        //    ApplicationUser user = await _userManager.FindByEmailAsync(email);
        //    var result = await _userManager.AddToRolesAsync(user, roles);

        //    return result;






        //}
    }
}
