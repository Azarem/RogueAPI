using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Spells
{
    public class DualBlades : SpellDefinition
    {
        public const byte Id = 9;
        public static readonly DualBlades Instance = new DualBlades();

        private DualBlades()
            : this(Id)
        {
            DisplayName = "Dagger";
            Icon = "DaggerIcon_Sprite";
            Description = string.Format("[Input:{0}]  Fires a dagger directly in front of you.", (int)Game.InputKeys.PlayerSpell1);
        }

        protected DualBlades(byte id)
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
