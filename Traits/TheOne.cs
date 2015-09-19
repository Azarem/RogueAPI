using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class TheOne : TraitDefinition
    {
        public const byte Id = 32;
        public static readonly TheOne Instance = new TheOne();

        protected TheOne()
            : base(Id)
        {
            this.DisplayName = "The One";
            this.Description = "There is no spork.";
            this.Rarity = 3;
        }
    }
}
