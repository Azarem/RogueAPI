namespace RogueAPI.Skills
{
    public class LichUp : SkillDefinition
    {
        public const byte Id = 30;
        public static readonly LichUp Instance = new LichUp();

        public LichUp()
            : base(Id)
        {
            DisplayName = "Upgrade Lich";
            Description = "Royalize your all-powerful Liches, and turn them into Lich Kings.";
            PerLevelModifier = 1f;
            BaseCost = 1500;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_LichUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to convert max hp into max mp");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
