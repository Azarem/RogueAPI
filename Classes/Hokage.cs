using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Hokage : Shinobi
    {
        new public const byte Id = 12;
        new public static readonly Hokage Instance = new Hokage();

        private Hokage()
            : this(Id)
        {
            this.DisplayName = "Hokage";
            this.Description = "A fast hero. Deal massive damage, but you cannot crit.\nSPECIAL: Replacement Technique.";
            this.ProfileCardDescription = "SPECIAL: Replacement Technique.\nHuge Str, but you cannot land critical strikes.\n +30% Move Speed.  Low HP and MP.";
        }

        protected Hokage(byte id)
            : base(id)
        {
        }
    }
}
