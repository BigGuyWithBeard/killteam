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
    public static class DataSeeder<TDbContext, TUser> where TDbContext : ApplicationDbContext<TUser> where TUser : ApplicationUser
    {

        /// <summary>Seeds the database with required data</summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <summary>To use call inside a .net core website using identity.
        /// in the Startup class, at teh end of the Configure() method:
        /// <code>TheCoderForge.Identity.DataSeeder.Initialise(app.ApplicationServices);</code>
        /// </summary>
        public static void Initialise(IServiceProvider serviceProvider)
        {

            var context = serviceProvider.GetService<TDbContext>();

            if (context == null)
            {
                Debugger.Break();
                throw new Exception("Database Context is null");
            }

            string[] roleArray = Enum.GetNames(typeof(UserRolesEnum));
            CreateRoles(context, roleArray);


            var user = (TUser)Activator.CreateInstance(typeof(TUser), new object[]
                                                                      {

                                                                      });
            //TODO find a way to use a constructor to set these properties.

            user.Id = Guid.NewGuid().ToString();
            user.Email = "smith.johnpaul@gmail.com";
            user.NormalizedEmail = user.Email.ToUpper();
            user.UserName = "smith.johnpaul@gmail.com";
            user.NormalizedUserName = user.UserName.ToUpper();
            user.PhoneNumber = "";
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = false;
            user.SecurityStamp = Guid.NewGuid().ToString("D");

            CreateUser(serviceProvider, context, user, roleArray, "P@ssw0rd");

            context.SaveChanges();

        }


        /// <summary>
        /// Creates the IdentityRoles for the application
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        /// <param name="roleNames">The role names.</param>
        private static void CreateRoles(TDbContext databaseContext, string[] roleNames)
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


        private static Boolean ValidatePassword(IServiceProvider serviceProvider, string password)
        {

            var userManager = serviceProvider.GetService<UserManager<TUser>>();

            List<string> passwordErrors = new List<string>();


            foreach (var validator in userManager.PasswordValidators)
            {
                var result = validator.ValidateAsync(userManager, null, password).Result;

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        passwordErrors.Add(error.Description);
                    }
                }
            }

            return passwordErrors.Count == 0;
        }
        /// <summary>Creates the default ApplicationUsers</summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="context">The context.</param>
        /// <param name="user">The user.</param>
        /// <param name="roles">The roles.</param>
        /// <remarks>Must be called after the IdentityRoles have been created.</remarks>
        private static void CreateUser(IServiceProvider serviceProvider, TDbContext context, TUser user, string[] roles, string password)
        {

            var passwordValid = ValidatePassword(serviceProvider, password);
            if (passwordValid == false)
            {
                Debugger.Break();
                throw new Exception("Password does not Validate");
            }


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                // user does not exist, so create it
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, password);

                var userStore = new UserStore<ApplicationUser>(context);
                userStore.CreateAsync(user).Wait();
            }

            AssignUserRoles(serviceProvider, user.Email, roles).Wait();

        }

        public static void SetUserPassword(TDbContext context, TUser user, string password)
        {
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                var hashed = passwordHasher.HashPassword(user, password);
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(user);

            }
        }/// <summary>Assigns the Identity Roles to default ApplicationUsers.</summary>
         /// <param name="serviceProvider">The service provider.</param>
         /// <param name="userEmail">The email.</param>
         /// <param name="roles">The roles.</param>
        public static async Task<IdentityResult> AssignUserRoles(IServiceProvider serviceProvider, string userEmail, string[] roles)
        {
            var userManager = serviceProvider.GetService<UserManager<TUser>>();
            var user = await userManager.FindByEmailAsync(userEmail);

            try
            {
                var rolesBeforeXXX = userManager.GetRolesAsync(user).Result;
            }
            catch (Exception e)
            {
                Debugger.Break();

            }

            //var rolesBefore = userManager.GetRolesAsync(user).Result;
            var result = await userManager.AddToRolesAsync(user, roles);


            // var rolesAfter = userManager.GetRolesAsync(user).Result;
            return result;

        }

    }
}
