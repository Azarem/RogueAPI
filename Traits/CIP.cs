using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class CIP : TraitDefinition
    {
        public const byte Id = 30;
        public static readonly CIP Instance = new CIP();

        protected CIP()
            : base(Id)
        {
            this.DisplayName = "C.I.P.";
            this.Description = "Congenital Insensitivity to Pain. Know no pain.";
            this.ProfileCardDescription = "No visible health bar.";
            this.Rarity = 3;
        }

        //PlayerHUDObj.Draw - Skip drawing HP bar & text
    }
}
