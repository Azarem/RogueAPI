using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class SpellSword2 : SpellSword
    {
        new public const byte Id = 14;
        new public static readonly SpellSword2 Instance = new SpellSword2();

        private SpellSword2()
            : this(Id)
        {
            this.DisplayName = "Spellsword";
            this.Description = "A hero for experts. Hit enemies to restore mana.\nSPECIAL: Empowered Spell.";
            this.ProfileCardDescription = "SPECIAL: Empowered Spell.\n30% of damage dealt is converted into mana.\nLow Str, HP, and MP.";
        }

        protected SpellSword2(byte id)
            : base(id)
        {
        }
    }
}
