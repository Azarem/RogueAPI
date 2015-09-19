using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Hypochondriac : TraitDefinition
    {
        public const byte Id = 25;
        public static readonly Hypochondriac Instance = new Hypochondriac();

        protected Hypochondriac()
            : base(Id)
        {
            this.DisplayName = "Hypochondriac";
            this.Description = "You tend to EXAGGERATE.";
            this.ProfileCardDescription = "Exaggerate the damage you take.";
            this.Rarity = 3;
        }
    }
}
