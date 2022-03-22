using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{
    class TacticalPloyModel
    {

        public Guid FactionId { get; set; }// ensure that a SP cannot be used to more than a single faction!
        public string Title { get; set; }
        public string Cost { get; set; } // in CP's
        public string Description { get; set; }

    }
}
