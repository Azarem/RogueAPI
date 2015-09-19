using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class SpellSword : ClassDefinition
    {
        public const byte Id = 6;
        public static readonly SpellSword Instance = new SpellSword();

        private SpellSword()
            : this(Id)
        {
            this.DisplayName = "Spellthief";
            this.Description = "A hero for experts. Hit enemies to restore mana.";
            this.ProfileCardDescription = "30% of damage dealt is converted into mana.\nLow Str, HP, and MP.";
        }

        protected SpellSword(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 0.75f;
            this.ManaMultiplier = 0.4f;

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
            this.AssignedSpells.Add(SpellDefinition.GetById(11));
        }
    }
}
