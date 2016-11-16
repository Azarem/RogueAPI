using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class BarbarianKing : Barbarian
    {
        new public const byte Id = 10;
        new public static readonly BarbarianKing Instance = new BarbarianKing();

        private BarbarianKing()
            : this(Id)
        {
            this.DisplayName = "Barbarian King";
            this.FemaleDisplayName = "Barbarian Queen";
            this.Description = "A walking tank. This hero can take a beating.\nSPECIAL: Barbarian Shout.";
            this.ProfileCardDescription = "SPECIAL: Barbarian Shout.\nHuge HP.  Low Str and MP.";
        }

        protected BarbarianKing(byte id)
            : base(id)
        {
        }
    }
}
