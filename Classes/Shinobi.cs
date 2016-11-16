using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Shinobi : ClassDefinition
    {
        public const byte Id = 4;
        public static readonly Shinobi Instance = new Shinobi();

        private Shinobi()
            : this(Id)
        {
            this.DisplayName = "Shinobi";
            this.Description = "A fast hero. Deal massive damage, but you cannot crit.";
            this.ProfileCardDescription = "Huge Str, but you cannot land critical strikes.\n +30% Move Speed.  Low HP and MP.";
        }

        public Shinobi(byte id)
            : base(id)
        {
            this.MoveSpeedMultiplier = 0.3f;
            this.PhysicalDamageMultiplier = 1.75f;
            this.HealthMultiplier = 0.6f;
            this.ManaMultiplier = 0.4f;
            this.CriticalChanceMultiplier = 0f;


            this.AssignedSpells.Add(Axe.Instance);
            this.AssignedSpells.Add(Dagger.Instance);
            this.AssignedSpells.Add(Translocator.Instance);
            this.AssignedSpells.Add(Chakram.Instance);
            this.AssignedSpells.Add(Scythe.Instance);
            this.AssignedSpells.Add(BladeWall.Instance);
            this.AssignedSpells.Add(Conflux.Instance);
        }
    }
}
