using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class FarSighted : TraitDefinition
    {
        public const byte Id = 4;
        public static readonly FarSighted Instance = new FarSighted();

        protected FarSighted()
            : base(Id)
        {
            this.DisplayName = "Far-Sighted";
            this.Description = "Anything close-up is blurry.";
            this.Rarity = 3;

            this.TraitConflicts.Add(NearSighted.Instance);
        }
    }
}
