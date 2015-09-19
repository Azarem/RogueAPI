using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Banker2 : Banker
    {
        new public const byte Id = 13;
        new public static readonly Banker2 Instance = new Banker2();

        private Banker2()
            : this(Id)
        {
            this.DisplayName = "Spelunker";
            this.FemaleDisplayName = "Spelunkette";
            this.Description = "A hero for hoarders. Very weak, but has a huge bonus to gold.\nSPECIAL: Ordinary Headlamp.";
            this.ProfileCardDescription = "SPECIAL: Ordinary Headlamp.\n+30% Gold gain.\nVery weak in all other stats.";
        }

        protected Banker2(byte id)
            : base(id)
        {
        }
    }
}
