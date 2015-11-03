using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class CritChanceUp : SkillDefinition
    {
        public const byte Id = 7;
        public static readonly CritChanceUp Instance = new CritChanceUp();

        protected CritChanceUp()
            : base(Id)
        {
            DisplayName = "Crit Chance Up";
            Description = "Teaching yourself about the weaknesses of enemies allows you to strike with deadly efficiency.";
            PerLevelModifier = 0.02f;
            BaseCost = 150;
            CostIncrement = 125;
            MaxLevel = 25;
            Icon = "Icon_Crit_Chance_UpLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }
    }
}
