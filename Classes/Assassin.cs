using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class Assassin : Knave
    {
        new public const byte Id = 11;
        new public static readonly Assassin Instance = new Assassin();

        private Assassin()
            : this(Id)
        {
            this.DisplayName = "Assassin";
            this.Description += "\nSPECIAL: Mist Form.";
            this.ProfileCardDescription = "SPECIAL: Mist Form\n" + this.ProfileCardDescription;
        }

        protected Assassin(byte id)
            : base(id)
        {
        }

        //PlayerObj.InputControls - Toggle mist form
    }
}
