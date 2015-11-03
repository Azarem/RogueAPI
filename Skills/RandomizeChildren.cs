namespace RogueAPI.Skills
{
    public class RandomizeChildren : SkillDefinition
    {
        public const byte Id = 20;
        public static readonly RandomizeChildren Instance = new RandomizeChildren();

        public RandomizeChildren()
            : base(Id)
        {
            DisplayName = "Randomize Children";
            Description = "Use the power of science to make a whole new batch of babies. Just... don't ask.";
            PerLevelModifier = 1f;
            BaseCost = 5000;
            CostIncrement = 5000;
            MaxLevel = 1;
            Icon = "Icon_RandomizeChildrenLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)9, "] to randomize your children");
            UnitText = "%";
            DisplayStat = false;
        }
    }
}
