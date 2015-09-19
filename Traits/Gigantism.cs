using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Gigantism : TraitDefinition
    {
        public const byte Id = 6;
        public static readonly Gigantism Instance = new Gigantism();

        protected Gigantism()
            : base(Id)
        {
            this.DisplayName = "Gigantism";
            this.Description = "You were born to be a basketball player.";
            this.ProfileCardDescription = "You are huge.";
            this.Rarity = 1;
        }
    }
}
