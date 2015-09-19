using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class PlatformsOpen : TraitDefinition
    {
        public const byte Id = 34;
        public static readonly PlatformsOpen Instance = new PlatformsOpen();

        protected PlatformsOpen()
            : base(Id)
        {
            this.DisplayName = "EHS";
            this.Description = "You conduct electricity really well.";
            this.ProfileCardDescription = "Platforms stay open.";
            this.Rarity = 2;
        }
    }
}
