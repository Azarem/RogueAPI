using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class PAD : TraitDefinition
    {
        public const byte Id = 23;
        public static readonly PAD Instance = new PAD();

        protected PAD()
            : base(Id)
        {
            this.DisplayName = "P.A.D.";
            this.Description = "Peripheral Arterial Disease. No foot pulse.";
            this.ProfileCardDescription = "No foot pulse.";
            this.Rarity = 2;
        }
    }
}
