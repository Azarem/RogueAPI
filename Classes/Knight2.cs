using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Knight2 : Knight
    {
        new public const byte Id = 8;
        new public static readonly Knight2 Instance = new Knight2();

        private Knight2() : this(Id) { }

        protected Knight2(byte id)
            : base(id)
        {
            this.DisplayName = "Paladin";
            this.Description = "Your standard hero. Pretty good at everything.\nSPECIAL: Guardian's Shield.";
            this.ProfileCardDescription = "SPECIAL: Guardian's Shield.\n100% Base stats.";
            //Set CanBlock
        }
    }
}
