using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class ColorBlind : TraitDefinition
    {
        public const byte Id = 1;
        public static readonly ColorBlind Instance = new ColorBlind();

        protected ColorBlind()
            : base(Id)
        {
            this.DisplayName = "Color Blind";
            this.Description = "You can't see colors due to monochromacy.";
            this.ProfileCardDescription = "You can't see colors.";
            this.Rarity = 2;
        }

        //ProceduralLevelScreen.Draw - Set Game.HSVEffect Saturation / Brightness / Contrast = 0 & apply to camera WHEN glasses are not active
        //SpecialItemRoomObj.RandomizeItem - 30% chance to get glasses item
        //FairyChallengeRoom.Draw - Ignore special camera transformations on boss death
        //FairyBossRoom.Draw - Ignore special camera transformations on boss death
    }
}
