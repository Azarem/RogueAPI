using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Vertigo : TraitDefinition
    {
        public const byte Id = 20;
        public static readonly Vertigo Instance = new Vertigo();

        protected Vertigo()
            : base(Id)
        {
            this.DisplayName = "Vertigo";
            this.Description = "Welcome to Barfs-ville.";
            this.ProfileCardDescription = "Everything is upside down.";
            this.Rarity = 3;
        }
    }
}
