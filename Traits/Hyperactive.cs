using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Hyperactive : TraitDefinition
    {
        public const byte Id = 14;
        public static readonly Hyperactive Instance = new Hyperactive();

        protected Hyperactive()
            : base(Id)
        {
            this.DisplayName = "ADHD";
            this.Description = "So energetic! You move faster.";
            this.ProfileCardDescription = "You move faster.";
            this.Rarity = 1;
        }
    }
}
