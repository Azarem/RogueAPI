using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class GoldGainUp : SkillDefinition
    {
        public const byte Id = 17;
        public static readonly GoldGainUp Instance = new GoldGainUp();

        public GoldGainUp()
            : base(Id)
        {
            DisplayName = "Gold Gain Up";
            Description = "Improve your looting skills, and get more bang for your buck.";
            PerLevelModifier = 0.1f;
            BaseCost = 1000;
            CostIncrement = 2150;
            MaxLevel = 5;
            Icon = "Icon_Gold_Gain_UpLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }
    }
}
