using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class ArmorUp : SkillDefinition
    {
        public const byte Id = 16;
        public static readonly ArmorUp Instance = new ArmorUp();

        public ArmorUp()
            : base(Id)
        {
            DisplayName = "Armor Up";
            Description = "Strengthen your innards through natural means to reduce incoming damage.";
            PerLevelModifier = 4f;
            BaseCost = 125;
            CostIncrement = 105;
            MaxLevel = 50;
            Icon = "Icon_ShieldLocked_Sprite";
            InputDescription = " ";
            UnitText = " armor";
            DisplayStat = true;
        }
    }
}
