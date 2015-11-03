using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class Smithy : SkillDefinition
    {
        public const byte Id = 12;
        public static readonly Smithy Instance = new Smithy();

        public Smithy()
            : base(Id)
        {
            DisplayName = "Smithy";
            Description = "Unlock the smithy and gain access to phat loot.";
            PerLevelModifier = 1f;
            BaseCost = 50;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_SmithyLocked_Sprite";
            InputDescription = " ";
            UnitText = "0";
            DisplayStat = false;
        }
    }
}
