using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{
    /// <summary>
    /// The melee weapons the operative can be equipped with, and their characteristics and rules when fighting in combat.
    /// </summary>
   public class MeleeWeaponProfileModel
    {

        /// <summary>
        /// Name: The name of the weapon.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Attacks (A): The starting number of attack dice to roll when the operative attacks with this weapon.
        /// </summary>
        /// <value>
        /// The attacks.
        /// </value>
        public int Attacks { get; set; }

        /// <summary>
        /// Weapon Skill (WS): How accurate and skilled the operative is when attacking with this weapon, represented by the result required when rolling a D6. Note that a lower result is a better characteristic.
        /// </summary>
        public int WeaponSkill { get; set; }

        /// <summary>
        /// Damage (Dmg): The amount of damage each attack dice can inflict. The first value is the Normal Damage characteristic. The second value is the Critical Damage characteristic.
        /// </summary>
        /// <value>
        /// The damage.
        /// </value>
        public int Damage { get; set; }


        /// <summary>
        /// Special Rules (SR): Any special rules that apply each time the operative attacks with this weapon. Common special rules are explained here. Special rules marked with a * are explained on the operative’s datacard.
        /// </summary>
        /// <value>
        /// The special rules.
        /// </value>
        public string SpecialRules { get; set; }

        /// <summary>
        /// Critical Hit Rules (!): Any additional effects the weapon can cause with critical hits.
        /// </summary>
        /// <value>
        /// The hit rules.
        /// </value>
        public string HitRules { get; set; }            
            

    }
}
