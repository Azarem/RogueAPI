namespace RogueAPI.Skills
{
    public class LichUnlock : SkillDefinition
    {
        public const byte Id = 21;
        public static readonly LichUnlock Instance = new LichUnlock();

        public LichUnlock()
            : base(Id)
        {
            DisplayName = "Unlock Lich";
            Description = "Release the power of the Lich! A being of massive potential.";
            PerLevelModifier = 1f;
            BaseCost = 850;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_LichUnlockLocked_Sprite";
            InputDescription = " ";
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
