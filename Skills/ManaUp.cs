using RogueAPI.Game;
using RogueAPI.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class ManaUp : SkillDefinition
    {
        public const byte Id = 10;
        public static readonly ManaUp Instance = new ManaUp();

        public ManaUp()
            : base(Id)
        {
            DisplayName = "Mana Up";
            Description = "Increase your mental fortitude in order to increase your mana pool. ";
            PerLevelModifier = 10f;
            BaseCost = 50;
            CostIncrement = 40;
            MaxLevel = 75;
            Icon = "Icon_ManaUpLocked_Sprite";
            InputDescription = " ";
            UnitText = " mp";
            DisplayStat = true;
        }

        protected override void Activate(Player player)
        {
            base.Activate(player);
            player.GetStatObject(ManaStat.Id).AddHandler(CalculateMana);
        }

        protected override void Deactivate(Player player)
        {
            player.GetStatObject(ManaStat.Id).RemoveHandler(CalculateMana);
            base.Deactivate(player);
        }

        protected override void LevelChanged(Player player)
        {
            base.LevelChanged(player);
            player.GetStatObject(ManaStat.Id).Invalidate();
        }

        private void CalculateMana(StatCalculation calc)
        {
            calc.BaseValue += ModifierTotal;
        }
    }
}
