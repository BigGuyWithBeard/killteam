using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{
    class SpecOpsModel
    {

        public Guid FactionId { get; set; }


        /// <summary>
        /// Unique Battle Honours available to operatives from that faction that gain a rank, no matter their chosen specialism.
        /// </summary>
        /// <value>
        /// The battle honours.
        /// </value>
        public List<string> BattleHonours { get; set; }

        /// <summary>
        /// A collection of rare equipment you can add to that faction's stash.
        /// </summary>
        /// <value>
        /// The rare equipment.
        /// </value>
        public List<string> RareEquipment { get; set; }

        /// <summary>
        /// Unique strategic assets you can add to that kill team's base of operations.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<string> Assets { get; set; }


        /// <summary>
        /// Specific requisitions you can use to further support that faction's kill team on their Spec Ops journey.
        /// </summary>
        /// <value>
        /// The requisitions.
        /// </value>
        public List<string> Requisitions { get; set; }

        /// <summary>
        /// Bespoke spec Ops you can assign to that faction's kill team
        /// </summary>
        /// <value>
        /// The spec ops.
        /// </value>
        public List<string> SpecOps { get; set; }
    }
}
