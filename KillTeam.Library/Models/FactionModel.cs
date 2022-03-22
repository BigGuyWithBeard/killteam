using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{
    
    /// <inheritdoc />
    /// <summary>Defines a faction within the game</summary>
    public class FactionModel: ModelBase

    {

        public string Archetype { get; set; }


        public List<string> AncillarySupport { get; set; }

        /// <summary>
        /// Any important abilities that faction's kill team has
        /// </summary>
        /// <value>
        /// The abilities.
        /// </value>
        public List<string> Abilities { get; set; }

        /// <summary>
        /// Bespoke Strategic Ploys available to this kill team
        /// </summary>
        /// <value>
        /// The strategic ploys.
        /// </value>
        public List<string> StrategicPloys { get; set; }

        /// <summary>
        /// Bespoke Tactical Ploys available to this kill team
        /// </summary>
        /// <value>
        /// The tactical ploys.
        /// </value>
         public List<string> TacticalPloys { get; set; }

        /// <summary>
        /// The rules for each operative that can be selected in that faction's kill team
        /// </summary>
        /// <value>
        /// The datacards.
        /// </value>
        public List<DatacardModel> Datacards { get; set; }

        /// <summary>
        /// A selection of equipment that operatives from that faction can be equipped with
        /// </summary>
        /// <value>
        /// The equipment.
        /// </value>
        public List<string> Equipment { get; set; }

    }
}
