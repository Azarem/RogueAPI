using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class CritDamageUp : SkillDefinition
    {
        public const byte Id = 8;
        public static readonly CritDamageUp Instance = new CritDamageUp();

        public CritDamageUp()
            : base(Id)
        {
            DisplayName = "Crit Damage Up";
            Description = "Practice the deadly strikes to be even deadlier. Enemies will be so dead.";
            PerLevelModifier = 0.05f;
            BaseCost = 150;
            CostIncrement = 125;
            MaxLevel = 25;
            Icon = "Icon_Crit_Damage_UpLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }
    }
}
