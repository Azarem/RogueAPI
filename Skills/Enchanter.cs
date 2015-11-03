using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class Enchanter : SkillDefinition
    {
        public const byte Id = 13;
        public static readonly Enchanter Instance = new Enchanter();

        public Enchanter()
            : base(Id)
        {
            DisplayName = "Enchantress";
            Description = "Unlock the enchantress and gain access to her magical runes and powers.";
            PerLevelModifier = 1f;
            BaseCost = 50;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_EnchanterLocked_Sprite";
            InputDescription = " ";
            UnitText = "0";
            DisplayStat = false;
        }
    }
}
