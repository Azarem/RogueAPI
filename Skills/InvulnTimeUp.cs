using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class InvulnTimeUp : SkillDefinition
    {
        public const byte Id = 3;
        public static readonly InvulnTimeUp Instance = new InvulnTimeUp();

        protected InvulnTimeUp()
            : base(Id)
        {
            DisplayName = "Invuln Time Up";
            Description = "Strengthen your adrenal glands and be invulnerable  like Bane. Let the games begin!";
            PerLevelModifier = 0.1f;
            BaseCost = 750;
            CostIncrement = 1700;
            MaxLevel = 5;
            Icon = "Icon_InvulnTimeUpLocked_Sprite";
            InputDescription = " ";
            UnitText = " sec";
            DisplayStat = true;
        }
    }
}
