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
            this.Description = "A risky hero. Low stats but can land devastating critical strikes.\nSPECIAL: Mist Form.";
            this.ProfileCardDescription = "SPECIAL: Mist Form\n+15% Crit. Chance, +125% Crit. Damage.\nLow HP, MP, and Str.";
        }

        protected Assassin2(byte id)
            : base(id)
        {
        }
    }
}
