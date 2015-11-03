using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class AttackUp : SkillDefinition
    {
        public const byte Id = 5;
        public static readonly AttackUp Instance = new AttackUp();

        public AttackUp()
            : base(Id)
        {
            DisplayName = "Attack Up";
            Description = "A proper gym will allow you to really  strengthen your arms and butt muscles.";
            PerLevelModifier = 2f;
            BaseCost = 100;
            CostIncrement = 85;
            MaxLevel = 75;
            Icon = "Icon_SwordLocked_Sprite";
            InputDescription = " ";
            UnitText = " str";
            DisplayStat = true;
        }
    }
}
