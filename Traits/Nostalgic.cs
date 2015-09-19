using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Nostalgic : TraitDefinition
    {
        public const byte Id = 29;
        public static readonly Nostalgic Instance = new Nostalgic();

        protected Nostalgic()
            : base(Id)
        {
            this.DisplayName = "Nostalgic";
            this.Description = "You miss the good old days.";
            this.ProfileCardDescription = "Everything is old-timey.";
            this.Rarity = 3;

            this.TraitConflicts.Add(ColorBlind.Instance);
        }
    }
}
