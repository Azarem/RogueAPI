using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Banker : ClassDefinition
    {
        public const byte Id = 5;
        public static readonly Banker Instance = new Banker();

        private Banker()
            : this(Id)
        {
            this.DisplayName = "Miner";
            this.Description = "A hero for hoarders. Very weak, but has a huge bonus to gold.";
            this.ProfileCardDescription = "+30% Gold gain.\nVery weak in all other stats.";
        }

        protected Banker(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 0.5f;
            this.ManaMultiplier = 0.5f;
            this.GoldBonus = 0.3f;

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(11));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }
    }
}
