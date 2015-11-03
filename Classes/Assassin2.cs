using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Assassin2 : Assassin
    {
        new public const byte Id = 11;
        new public static readonly Assassin2 Instance = new Assassin2();

        private Assassin2()
            : this(Id)
        {
            this.DisplayName = "Assassin";
            this.Description += "\nSPECIAL: Mist Form.";
            this.ProfileCardDescription = "SPECIAL: Mist Form\n" + this.ProfileCardDescription;
        }

        protected Assassin2(byte id)
            : base(id)
        {
        }

        //PlayerObj.InputControls - Toggle mist form
    }
}
