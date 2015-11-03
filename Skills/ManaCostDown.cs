using RogueAPI.Game;
using RogueAPI.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class ManaCostDown : SkillDefinition
    {
        public const byte Id = 11;
        public static readonly ManaCostDown Instance = new ManaCostDown();

        public ManaCostDown()
            : base(Id)
        {
            DisplayName = "Mana Cost Down";
            Description = "Practice your basics to reduce mana costs when casting spells.";
            PerLevelModifier = 0.05f;
            BaseCost = 750;
            CostIncrement = 1700;
            MaxLevel = 5;
            Icon = "Icon_ManaCostDownLocked_Sprite";
            InputDescription = " ";
            UnitText = "%";
            DisplayStat = true;
        }

        protected override void Activate(Player player)
        {
            base.Activate(player);
            player.GetStatObject(ManaCostStat.Id).AddHandler(CalculatingManaCost);
        }

        protected override void Deactivate(Player player)
        {
            player.GetStatObject(ManaCostStat.Id).RemoveHandler(CalculatingManaCost);
            base.Deactivate(player);
        }

        protected virtual void CalculatingManaCost(StatCalculation calc)
        {
            calc.Multiplier *= 1.0f - ModifierTotal;
        }
    }
}
