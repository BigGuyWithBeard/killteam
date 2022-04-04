using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KillTeam.Web.Models;

namespace KillTeam.Web.Data
{
    public class KillTeamWebContext : DbContext
    {
        public KillTeamWebContext (DbContextOptions<KillTeamWebContext> options)
            : base(options)
        {
        }

        public DbSet<KillTeam.Web.Models.Faction> Faction { get; set; }
    }
}
