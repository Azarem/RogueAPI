using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class TunnelVision : TraitDefinition
    {
        public const byte Id = 21;
        public static readonly TunnelVision Instance = new TunnelVision();

        protected TunnelVision()
            : base(Id)
        {
            this.DisplayName = "Tunnel Vision";
            this.Description = "No peripheral vision.";
            this.ProfileCardDescription = "No early indicators.";
            this.Rarity = 2;
        }
    }
}
