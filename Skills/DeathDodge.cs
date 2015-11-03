using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class DeathDodge : SkillDefinition
    {
        public const byte Id = 4;
        public static readonly DeathDodge Instance = new DeathDodge();

        public DeathDodge()
            : base(Id)
        {
            DisplayName = "Death Defy";
            Description = "Release your inner cat, and avoid death. Sometimes.";
            PerLevelModifier = 0.015f;
            BaseCost = 750;
            CostIncrement = 1500;
            MaxLevel = 10;
            Icon = "Icon_DeathDefyLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }
    }
}
