using Microsoft.EntityFrameworkCore;
using TheCoderForge.Identity;
using KillTeam.WebRazor.Models;

namespace KillTeam.WebRazor
{
    public class KillTeamDbContext: ApplicationDbContext<KillTeamUser>
    {
        public KillTeamDbContext(DbContextOptions options) : base(options) {}
        public DbSet<GovernmentModel> GovernmentModel { get; set; }
        public DbSet<KillTeam.WebRazor.Models.Article> Article { get; set; }

    }
}
