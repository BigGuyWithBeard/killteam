using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{
    public class TacOpsModel
    {
        public Guid FactionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }// in action Points (AP)

    }
}
