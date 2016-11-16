using System;
using System.Linq;

namespace RogueAPI.Classes
{
    public class LichKing : Lich
    {
        new public const byte Id = 15;
        new public static readonly LichKing Instance = new LichKing();

        private LichKing()
            : this(Id)
        {
            this.DisplayName = "Lich King";
            this.FemaleDisplayName = "Lich Queen";
            this.Description = "Feed off the dead. Gain permanent life for every kill up to a cap. Extremely intelligent.\nSPECIAL: HP Conversion.";
            this.ProfileCardDescription = "SPECIAL: HP Conversion.\nKills are coverted into max HP.\nVery low Str, HP and MP.  High Int.";
        }

        protected LichKing(byte id)
            : base(id)
        {
        }
    }
}
