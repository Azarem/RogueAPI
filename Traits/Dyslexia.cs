using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Dyslexia : TraitDefinition
    {
        public const byte Id = 5;
        public static readonly Dyslexia Instance = new Dyslexia();

        protected Dyslexia()
            : base(Id)
        {
            this.DisplayName = "Dyslexia";
            this.Description = "You hvae trboule raednig tinhgs.";
            this.Rarity = 3;
        }

        //ProceduralLevelScreen.CheckForRoomTransition - Randomize room title text on transition
        //DialogueScreen.SetDialogueChoice - Randomize dialog choices
        //DialogueScreen.HandleInput - Randomize content as it is paged
        //DialogueScreen.OnEnter - Randomize initial content
    }
}
