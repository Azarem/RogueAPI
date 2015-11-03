namespace RogueAPI.Skills
{
    public class NinjaUp : SkillDefinition
    {
        public const byte Id = 31;
        public static readonly NinjaUp Instance = new NinjaUp();

        public NinjaUp()
            : base(Id)
        {
            DisplayName = "Upgrade Shinobi";
            Description = "Become the leader of your village, and turn your Shinobi into a Hokage. Believe it!";
            PerLevelModifier = 1f;
            BaseCost = 750;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_NinjaUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to flash");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
