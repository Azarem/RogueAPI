using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class NoFurniture : TraitDefinition
    {
        public const byte Id = 33;
        public static readonly NoFurniture Instance = new NoFurniture();

        protected NoFurniture()
            : base(Id)
        {
            this.DisplayName = "Clumsy";
            this.Description = "You break a lot of things.";
            this.ProfileCardDescription = "You break stuff and have no balance.";
            this.Rarity = 2;
        }
    }
}
