using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Endomorph : TraitDefinition
    {
        public const byte Id = 9;
        public static readonly Endomorph Instance = new Endomorph();

        protected Endomorph()
            : base(Id)
        {
            this.DisplayName = "Endomorph";
            this.Description = "You're so heavy, enemies can't knock you back.";
            this.ProfileCardDescription = "Can't get knocked back.";
            this.Rarity = 1;
        }
    }
}
