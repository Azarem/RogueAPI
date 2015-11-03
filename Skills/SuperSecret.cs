namespace RogueAPI.Skills
{
    public class SuperSecret : SkillDefinition
    {
        public const byte Id = 33;
        public static readonly SuperSecret Instance = new SuperSecret();

        public SuperSecret()
            : base(Id)
        {
            DisplayName = "Beastiality";
            Description = "Half man, half ******, all awesome.";
            PerLevelModifier = 10f;
            BaseCost = 5000;
            CostIncrement = 30;
            MaxLevel = 1;
            Icon = "Icon_Display_Boss_RoomsLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)10, "] to awesome.");
            UnitText = "hp";
            DisplayStat = true;
        }
    }
}
