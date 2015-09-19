using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Alzheimers : TraitDefinition
    {
        public const byte Id = 11;
        public static readonly Alzheimers Instance = new Alzheimers();

        protected Alzheimers()
            : base(Id)
        {
            this.DisplayName = "Alzheimers";
            this.Description = "You have trouble remembering where you are.";
            this.ProfileCardDescription = "Where are you?";
            this.Rarity = 3;
        }

        //MapScreen.OnEnter - Set DrawNothing = true
        //MapScreen.Draw - Draw alzheimers question marks
    }
}
