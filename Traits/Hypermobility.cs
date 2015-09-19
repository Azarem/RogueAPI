using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Hypermobility : TraitDefinition
    {
        public const byte Id = 27;
        public static readonly Hypermobility Instance = new Hypermobility();

        protected Hypermobility()
            : base(Id)
        {
            this.DisplayName = "Flexible";
            this.Description = "You are very flexible.";
            this.ProfileCardDescription = "You turn while fighting.";
            this.Rarity = 2;
        }
    }
}
