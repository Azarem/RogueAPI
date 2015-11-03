using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Spells
{
    public class DamageShield : SpellDefinition
    {
        public const byte Id = 11;
        public static readonly DamageShield Instance = new DamageShield();

        private DamageShield()
            : this(Id)
        {
            DisplayName = "Dagger";
            Icon = "DaggerIcon_Sprite";
            Description = string.Format("[Input:{0}]  Fires a dagger directly in front of you.", (int)Game.InputKeys.PlayerSpell1);
        }

        protected DamageShield(byte id)
            : base(id)
        {
            MiscValue1 = 0f;
            MiscValue2 = 0f;
            Rarity = 1;
            ManaCost = 10;
            DamageMultiplier = 1.0f;
        }
    }
}
