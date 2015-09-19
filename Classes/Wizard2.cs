using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Wizard2 : Wizard
    {
        new public const byte Id = 9;
        new public static readonly Wizard2 Instance = new Wizard2();

        private Wizard2() : this(Id) { }

        protected Wizard2(byte id)
            : base(id)
        {
            this.DisplayName = "Archmage";
            this.Description = "A powerful spellcaster. Every kill gives you mana.\nSPECIAL: Spell Cycle.";
            this.ProfileCardDescription = "SPECIAL: Spell Cycle.\nEvery kill gives you 6 mana.\nLow Str and HP.  High Int and MP.";
            //this.PhysicalDamageMultiplier = 0.5f;
            //this.HealthMultiplier = 0.5f;
            //this.ManaMultiplier = 1.5f;
            //this.MagicDamageMultiplier = 1.25f;
        }
    }
}
