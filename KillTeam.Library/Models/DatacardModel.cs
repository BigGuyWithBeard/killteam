using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillTeam.Library.Models
{
    /// <summary>
    /// The rules for each operative that can be selected in that faction's kill team
    /// </summary>
    public class DatacardModel: ModelBase
    {
        // Move(M): This is the speed at which a model moves across the battlefield
        public int MovementSize { get; set; }
        public DistanceEnum MovementScale { get; set; }

        // Action Point Limit (APL): The number of action points an operative generates when it is activated, which are used to perform actions.
        public int ActionPointLimit { get; set; }

        // Group Activation (GA): Most operatives are activated individually, but some operatives must be activated in a group. This number states how many of these operatives are activated together.
        public int GroupActivation { get; set; }

        // Defence (Df): How many attacks the operative can defend each time another operative attacks it with a ranged weapon.
        public int Defence { get; set; }

        // Save (Sv): How likely the operative is to avert an attack each time another operative attacks it with a ranged weapon, represented by the result required when rolling a D6. Note that a lower result is a better characteristic.
        public int Save { get; set;}

        // Wounds (W): How many wounds an operative can lose before it is incapacitated.
        public int Wounds { get; set; }

        /// <summary>
        /// The ranged weapons the operative can be equipped with, and their characteristics and rules when shooting.
        /// </summary>
        public List<RangedWeaponProfileModel> RangedWeaponProfiles { get; set; }

        /// <summary>
        /// The melee weapons the operative can be equipped with, and their characteristics and rules when fighting in combat.
        /// </summary>
        public List<MeleeWeaponProfileModel> MeleeWeaponProfiles { get; set; }


        public string Abilities { get; set; }
        public string UniqueActions { get; set; }
        public List<string> Keywords { get; set; }

        #region Kill Team 19

        // the following are from kill team '19
        //// Weapon Skill (WS): This tells you a model's skill at hand-to-hand fighting. If a model has a Weapon Skill of '-' it is unable to fight in melee and cannot make close combat attacks at all.
        //public int WeaponSkill { get; set; }

        //// Ballistic Skill (BS): This shows how accurate a model is when shooting with ranged weapons. If a model has a Ballistic Skill of '-' it has no proficiency with ranged weapons and cannot make shooting attacks at all.
        //public int BallisticsSkill { get; set; }

        //// Strength (S): This indicates how strong a model is and how likely it is to inflict damage in hand-to-hand combat.
        //public int Strength { get; set; }

        //// Toughness (T): This reflects the model's resilience against physical harm.
        //public int Toughness { get; set; }

        //// Wounds (W): Wounds show how much damage a model can sustain before it succumbs to its injuries.
        //public int Wounds { get; set; }

        //// Attacks (A): This tells you how many times a model can strike blows in hand-to-hand combat.
        //public int Attacks { get; set; }

        //// Leadership (Ld): This reveals how courageous, determined or self-controlled a model is.
        //public int Leadership { get; set; }

        //// Save (Sv): This indicates the protection a model's armour gives.
        //public int Save { get; set; }

        //// Maximum Number (Max): This number tells you how many of this model you can include in a kill team.
        //public int Maximum { get; set; }

        #endregion
    }
}
