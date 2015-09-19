using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Dementia : TraitDefinition
    {
        public const byte Id = 26;
        public static readonly Dementia Instance = new Dementia();

        protected Dementia()
            : base(Id)
        {
            this.DisplayName = "Dementia";
            this.Description = "You are insane.";
            this.ProfileCardDescription = "You see things that aren't there.";
            this.Rarity = 3;
        }

        //ProceduralLevelScreen.CheckForRoomTransition - 20% chance to spawn dementia enemy for standard rooms
    }
}
