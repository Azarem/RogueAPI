using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Paladin : Knight
    {
        new public const byte Id = 8;
        new public static readonly Paladin Instance = new Paladin();

        private Paladin() : this(Id) { }

        protected Paladin(byte id)
            : base(id)
        {
            this.DisplayName = "Paladin";
            this.Description = "Your standard hero. Pretty good at everything.\nSPECIAL: Guardian's Shield.";
            this.ProfileCardDescription = "SPECIAL: Guardian's Shield.\n100% Base stats.";
            //Set CanBlock
        }
    }
}
