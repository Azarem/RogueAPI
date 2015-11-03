using System;
using System.Linq;

namespace RogueAPI.Spells
{
    public class Dagger : SpellDefinition
    {
        public const byte Id = 1;
        public static readonly Dagger Instance = new Dagger();

        private Dagger()
            : this(Id)
        {
            DisplayName = "Dagger";
            Icon = "DaggerIcon_Sprite";
            Description = string.Format("[Input:{0}]  Fires a dagger directly in front of you.", (int)Game.InputKeys.PlayerSpell1);
        }

        protected Dagger(byte id)
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
