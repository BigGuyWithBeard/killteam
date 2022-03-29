using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KillTeam.WebApp.Models;

namespace KillTeam.WebApp.Data
{
    public class KillTeamWebAppContext : DbContext
    {
        public KillTeamWebAppContext (DbContextOptions<KillTeamWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<KillTeam.WebApp.Models.MinifigureModel> MinifigureModel { get; set; }
    }
}
