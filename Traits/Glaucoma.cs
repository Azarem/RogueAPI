using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Glaucoma : TraitDefinition
    {
        public const byte Id = 35;
        public static readonly Glaucoma Instance = new Glaucoma();

        protected Glaucoma()
            : base(Id)
        {
            this.DisplayName = "Glaucoma";
            this.Description = "It's so dark.";
            this.Rarity = 2;
        }
    }
}
