using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Ninja : ClassDefinition
    {
        public const byte Id = 4;
        public static readonly Ninja Instance = new Ninja();

        private Ninja()
            : this(Id)
        {
            this.DisplayName = "Shinobi";
            this.Description = "A fast hero. Deal massive damage, but you cannot crit.";
            this.ProfileCardDescription = "Huge Str, but you cannot land critical strikes.\n +30% Move Speed.  Low HP and MP.";
        }

        public Ninja(byte id)
            : base(id)
        {
            this.MoveSpeedMultiplier = 0.3f;
            this.PhysicalDamageMultiplier = 1.75f;
            this.HealthMultiplier = 0.6f;
            this.ManaMultiplier = 0.4f;
            this.CriticalChanceMultiplier = 0f;


            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(6));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }
    }
}
