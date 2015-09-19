using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class NearSighted : TraitDefinition
    {
        public const byte Id = 3;
        public static readonly NearSighted Instance = new NearSighted();

        protected NearSighted()
            : base(Id)
        {
            this.DisplayName = "Near-Sighted";
            this.Description = "Anything far away is blurry.";
            this.Rarity = 2;
        }
    }
}
