using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueAPI.Game;
using RogueAPI.Stats;

namespace RogueAPI.Skills
{
    public class HealthUp : SkillDefinition
    {
        public const byte Id = 2;
        public static readonly HealthUp Instance = new HealthUp();

        protected HealthUp() : base(Id)
        {
            DisplayName = "Health Up";
            Description = "Improve your cardio workout. A better heart means better health.";
            PerLevelModifier = 10f;
            BaseCost = 50;
            CostIncrement = 40;
            MaxLevel = 75;
            Icon = "Icon_Health_UpLocked_Sprite";
            InputDescription = " ";
            UnitText = " hp";
            DisplayStat = true;
        }

        protected override void Activate(Player player)
        {
            base.Activate(player);
            player.GetStatObject(HealthStat.Id).AddHandler(CalculateHealth);
        }

        protected override void Deactivate(Player player)
        {
            player.GetStatObject(HealthStat.Id).RemoveHandler(CalculateHealth);
            base.Deactivate(player);
        }

        protected override void LevelChanged(Player player)
        {
            base.LevelChanged(player);
            player.GetStatObject(HealthStat.Id).Invalidate();
        }

        private void CalculateHealth(StatCalculation calc)
        {
            calc.BaseValue += ModifierTotal;
        }
    }
}
