using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Ninja2 : Ninja
    {
        new public const byte Id = 12;
        new public static readonly Ninja2 Instance = new Ninja2();

        private Ninja2()
            : this(Id)
        {
            this.DisplayName = "Hokage";
            this.Description = "A fast hero. Deal massive damage, but you cannot crit.\nSPECIAL: Replacement Technique.";
            this.ProfileCardDescription = "SPECIAL: Replacement Technique.\nHuge Str, but you cannot land critical strikes.\n +30% Move Speed.  Low HP and MP.";
        }

        protected Ninja2(byte id)
            : base(id)
        {
        }
    }
}
