using Microsoft.EntityFrameworkCore;
using TheCoderForge.Identity;

namespace KillTeam.WebRazor
{
    public class KillTeamDbContext: ApplicationDbContext<KillTeamUser>
    {
        public KillTeamDbContext(DbContextOptions options) : base(options) {}

        

    }
}
