using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class IBS : TraitDefinition
    {
        public const byte Id = 19;
        public static readonly IBS Instance = new IBS();

        protected IBS()
            : base(Id)
        {
            this.DisplayName = "I.B.S.";
            this.Description = "Even the most valiant heroes can suffer from irritable bowels.";
            this.ProfileCardDescription = "You fart a lot.";
            this.Rarity = 2;
        }
    }
}
