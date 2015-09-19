using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class OCD : TraitDefinition
    {
        public const byte Id = 15;
        public static readonly OCD Instance = new OCD();

        protected OCD()
            : base(Id)
        {
            this.DisplayName = "O.C.D.";
            this.Description = "Must. Clear. House. Break stuff to restore MP.";
            this.ProfileCardDescription = "Break stuff to restore MP.";
            this.Rarity = 1;
        }
    }
}
