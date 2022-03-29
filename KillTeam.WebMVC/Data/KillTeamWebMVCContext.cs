using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KillTeam.WebMVC.Models;

namespace KillTeam.WebMVC.Data
{
    public class KillTeamWebMVCContext : DbContext
    {
        public KillTeamWebMVCContext (DbContextOptions<KillTeamWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<KillTeam.WebMVC.Models.Minifigure> Minifigure { get; set; }
    }
}
