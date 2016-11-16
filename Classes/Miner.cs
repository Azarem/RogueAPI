using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Miner : ClassDefinition
    {
        public const byte Id = 5;
        public static readonly Miner Instance = new Miner();

        private Miner()
            : this(Id)
        {
            this.DisplayName = "Miner";
            this.Description = "A hero for hoarders. Very weak, but has a huge bonus to gold.";
            this.ProfileCardDescription = "+30% Gold gain.\nVery weak in all other stats.";
        }

        protected Miner(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 0.5f;
            this.ManaMultiplier = 0.5f;
            this.GoldBonus = 0.3f;

            this.AssignedSpells.Add(Axe.Instance);
            this.AssignedSpells.Add(Dagger.Instance);
            this.AssignedSpells.Add(Chakram.Instance);
            this.AssignedSpells.Add(Scythe.Instance);
            this.AssignedSpells.Add(FlameBarrier.Instance);
            this.AssignedSpells.Add(Conflux.Instance);
        }

        //ProfileCardScreen.SetPlayerStyle - Change player part 15 to lamp sprite
        //PlayerObj.ChangeSprite - Change player part 15 to lamp sprite
        //CreditsScreen.SetPlayerStyle
    }
}
