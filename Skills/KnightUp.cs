using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class KnightUp : SkillDefinition
    {
        public const byte Id = 25;
        public static readonly KnightUp Instance = new KnightUp();

        public KnightUp()
            : base(Id)
        {
            DisplayName = "Upgrade Knight";
            Description = "Turn your knights into Paladins. A ferocious forefront fighter.";
            PerLevelModifier = 1f;
            BaseCost = 50;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_KnightUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to block all incoming damage.");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
