namespace RogueAPI.Skills
{
    public class BankerUnlock : SkillDefinition
    {
        public const byte Id = 22;
        public static readonly BankerUnlock Instance = new BankerUnlock();

        public BankerUnlock()
            : base(Id)
        {
            DisplayName = "Unlock Miner";
            Description = "Unlock the skills of the Miner and raise your family fortune";
            PerLevelModifier = 1f;
            BaseCost = 400;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_SpelunkerUnlockLocked_Sprite";
            InputDescription = " ";
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
