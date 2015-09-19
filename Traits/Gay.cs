using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Gay : TraitDefinition
    {
        public const byte Id = 2;
        public static readonly Gay Instance = new Gay();

        protected Gay()
            : base(Id)
        {
            this.DisplayName = "Gay";
            this.Description = "You are a fan of the man.";
            this.FemaleDescription = "You like the ladies.";
            this.Rarity = 1;
        }
    }
}
