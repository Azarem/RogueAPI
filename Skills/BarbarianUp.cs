using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class BarbarianUp : SkillDefinition
    {
        public const byte Id = 29;
        public static readonly BarbarianUp Instance = new BarbarianUp();

        public BarbarianUp()
            : base(Id)
        {
            DisplayName = "Upgrade Barbarian";
            Description = "Become a Barbarian King.  The king of freemen. That makes no sense.";
            PerLevelModifier = 1f;
            BaseCost = 300;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_BarbarianUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to cast an epic shout that knocks virtually everything away.");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
