
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TheCoderForge.Identity
{
    public abstract class ApplicationDbContext<TUser> : IdentityDbContext<ApplicationUser>  where TUser: ApplicationUser
    {

        protected ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<TUser> Users { get; set; }
    }
}