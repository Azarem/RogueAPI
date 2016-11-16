using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Spelunker : Miner
    {
        new public const byte Id = 13;
        new public static readonly Spelunker Instance = new Spelunker();

        private Spelunker()
            : this(Id)
        {
            this.DisplayName = "Spelunker";
            this.FemaleDisplayName = "Spelunkette";
            this.Description += "\nSPECIAL: Ordinary Headlamp.";
            this.ProfileCardDescription = "SPECIAL: Ordinary Headlamp.\n" + this.ProfileCardDescription;
        }

        protected Spelunker(byte id)
            : base(id)
        {
        }
    }
}
