using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Ectomorph : TraitDefinition
    {
        public const byte Id = 10;
        public static readonly Ectomorph Instance = new Ectomorph();

        protected Ectomorph()
            : base(Id)
        {
            this.DisplayName = "Ectomorph";
            this.Description = "You're skinny, so every hit sends you flying.";
            this.ProfileCardDescription = "Hits send you flying.";
            this.Rarity = 2;

            this.TraitConflicts.Add(Gigantism.Instance);
        }
    }
}
