using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class MagicDamageUp : SkillDefinition
    {
        public const byte Id = 9;
        public static readonly MagicDamageUp Instance = new MagicDamageUp();

        public MagicDamageUp()
            : base(Id)
        {
            DisplayName = "Magic Damage Up";
            Description = "Learn the secrets of the universe, so you can use it to kill with spells better.";
            PerLevelModifier = 2f;
            BaseCost = 100;
            CostIncrement = 85;
            MaxLevel = 75;
            Icon = "Icon_MagicDmgUpLocked_Sprite";
            InputDescription = " ";
            UnitText = " int";
            DisplayStat = false;
        }
    }
}
