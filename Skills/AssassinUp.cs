using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class AssassinUp : SkillDefinition
    {
        public const byte Id = 27;
        public static readonly AssassinUp Instance = new AssassinUp();

        public AssassinUp()
            : base(Id)
        {
            DisplayName = "Upgrade Knave";
            Description = "Learn the dark arts, and turn the Knave into an Assassin";
            PerLevelModifier = 1f;
            BaseCost = 300;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_AssassinUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to turn to mist");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
