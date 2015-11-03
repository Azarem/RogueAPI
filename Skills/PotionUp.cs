using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class PotionUp : SkillDefinition
    {
        public const byte Id = 19;
        public static readonly PotionUp Instance = new PotionUp();

        public PotionUp()
            : base(Id)
        {
            DisplayName = "Potion Up";
            Description = "Gut cleansing leads to noticable improvements from both potions and meat.";
            PerLevelModifier = 0.01f;
            BaseCost = 750;
            CostIncrement = 1750;
            MaxLevel = 5;
            Icon = "Icon_PotionUpLocked_Sprite";
            InputDescription = " ";
            UnitText = "% hp/mp";
            DisplayStat = false;
        }
    }
}
