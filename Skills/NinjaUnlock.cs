using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class NinjaUnlock : SkillDefinition
    {
        public const byte Id = 24;
        public static readonly NinjaUnlock Instance = new NinjaUnlock();

        public NinjaUnlock()
            : base(Id)
        {
            DisplayName = "Unlock Shinobi";
            Description = "Unlock the Shinobi, the fleetest of fighters.";
            PerLevelModifier = 1f;
            BaseCost = 400;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_NinjaUnlockLocked_Sprite";
            InputDescription = " ";
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
