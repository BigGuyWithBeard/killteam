using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheCoderForge.Identity;

namespace KillTeam.WebRazor.Data
{
    //public class DataSeeder: TheCoderForge.Identity.DataSeeder
    //{
    ////    /// <summary>Seeds the database with required data</summary>
    ////    /// <param name="serviceProvider">The service provider.</param>
    ////    public void InitialiseXXX(IServiceProvider serviceProvider)
    ////    {


    ////        // use the Microsoft.Extension.DependencyInjection.ServiceProviderServiceExtensions.Creation
    ////        // extension method to resolve the scoped ApplicationDbContext from the service provider 
    ////        using (var serviceScope = serviceProvider.CreateScope()) // 
    ////        {
    ////            var context = serviceScope.ServiceProvider.GetService<IdentityDbContext>(); // ApplicationDbContext

    ////          //  string[] roleArray = Enum.GetNames(typeof(UserRolesEnum));
    ////         //   CreateRoles(context, roleArray);


    ////            //var user = new ApplicationUser
    ////            //           {
    ////            //               // FirstName = "XXXX",
    ////            //               // LastName = "XXXX",
    ////            //               Email = "xxxx@example.com"
    ////            //             , NormalizedEmail = "XXXX@EXAMPLE.COM"
    ////            //             , UserName = "Owner"
    ////            //             , NormalizedUserName = "OWNER"
    ////            //             , PhoneNumber = "+111111111111"
    ////            //             , EmailConfirmed = true
    ////            //             , PhoneNumberConfirmed = true
    ////            //             , SecurityStamp = Guid.NewGuid().ToString("D")
    ////            //           };

    ////        }

    //}
}
