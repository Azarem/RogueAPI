using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class EideticMemory : TraitDefinition
    {
        public const byte Id = 28;
        public static readonly EideticMemory Instance = new EideticMemory();

        protected EideticMemory()
            : base(Id)
        {
            this.DisplayName = "Eid. Mem.";
            this.Description = "You remember things with extreme clarity.";
            this.ProfileCardDescription = "Remember enemy placement.";
            this.Rarity = 2;
        }
    }
}
