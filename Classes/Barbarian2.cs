using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Barbarian2 : Barbarian
    {
        new public const byte Id = 10;
        new public static readonly Barbarian2 Instance = new Barbarian2();

        private Barbarian2()
            : this(Id)
        {
            this.DisplayName = "Barbarian King";
            this.FemaleDisplayName = "Barbarian Queen";
            this.Description = "A walking tank. This hero can take a beating.\nSPECIAL: Barbarian Shout.";
            this.ProfileCardDescription = "SPECIAL: Barbarian Shout.\nHuge HP.  Low Str and MP.";
        }

        protected Barbarian2(byte id)
            : base(id)
        {
        }
    }
}
