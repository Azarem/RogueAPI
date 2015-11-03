using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class PricesDown : SkillDefinition
    {
        public const byte Id = 18;
        public static readonly PricesDown Instance = new PricesDown();

        public PricesDown()
            : base(Id)
        {
            DisplayName = "Haggle";
            Description = "Lower Charon's toll by learning how to barter with death itself.";
            PerLevelModifier = 0.1f;
            BaseCost = 500;
            CostIncrement = 1000;
            MaxLevel = 5;
            Icon = "Icon_HaggleLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }
    }
}
