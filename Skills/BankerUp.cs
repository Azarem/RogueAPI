using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class BankerUp : SkillDefinition
    {
        public const byte Id = 28;
        public static readonly BankerUp Instance = new BankerUp();

        public BankerUp()
            : base(Id)
        {
            DisplayName = "Upgrade Miner";
            Description = "Earn your geology degree and go from Miner to Spelunker. Spiffy.";
            PerLevelModifier = 1f;
            BaseCost = 1750;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_SpelunkerUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to turn on your headlamp");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
