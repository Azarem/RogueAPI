using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Tourettes : TraitDefinition
    {
        public const byte Id = 13;
        public static readonly Tourettes Instance = new Tourettes();

        protected Tourettes()
            : base(Id)
        {
            this.DisplayName = "Coprolalia";
            this.Description = "%#&@!";
            this.Rarity = 1;
        }
    }
}
