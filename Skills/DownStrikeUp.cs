using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class DownStrikeUp : SkillDefinition
    {
        public const byte Id = 6;
        public static readonly DownStrikeUp Instance = new DownStrikeUp();

        protected DownStrikeUp()
            : base(Id)
        {
            DisplayName = "Down Strike Up";
            Description = "A pogo practice room has its benefits. Deal more damage with consecutive down strikes.";
            PerLevelModifier = 0.05f;
            BaseCost = 750;
            CostIncrement = 1500;
            MaxLevel = 5;
            Icon = "Icon_Attack_UpLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }
    }
}
