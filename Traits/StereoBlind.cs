using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class StereoBlind : TraitDefinition
    {
        public const byte Id = 18;
        public static readonly StereoBlind Instance = new StereoBlind();

        protected StereoBlind()
            : base(Id)
        {
            this.DisplayName = "Stereo Blind";
            this.Description = "You can't see in 3D.";
            this.Rarity = 1;
        }
    }
}
