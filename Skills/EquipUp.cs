using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class EquipUp : SkillDefinition
    {
        public const byte Id = 15;
        public static readonly EquipUp Instance = new EquipUp();

        public EquipUp()
            : base(Id)
        {
            DisplayName = "Equip Up";
            Description = "Upgrading your carry capacity will allow you to wear better and heavier armor.";
            PerLevelModifier = 10f;
            BaseCost = 50;
            CostIncrement = 40;
            MaxLevel = 50;
            Icon = "Icon_Equip_UpLocked_Sprite";
            InputDescription = " ";
            UnitText = " weight";
            DisplayStat = true;
        }
    }
}
