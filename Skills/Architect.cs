namespace RogueAPI.Skills
{
    public class Architect : SkillDefinition
    {
        public const byte Id = 14;
        public static readonly Architect Instance = new Architect();

        public Architect()
            : base(Id)
        {
            DisplayName = "Architect";
            Description = "Unlock the architect and gain the powers to lock down the castle.";
            PerLevelModifier = 1f;
            BaseCost = 50;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_ArchitectLocked_Sprite";
            InputDescription = " ";
            UnitText = "0";
            DisplayStat = false;
        }
    }
}
