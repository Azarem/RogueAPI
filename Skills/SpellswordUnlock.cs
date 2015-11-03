namespace RogueAPI.Skills
{
    public class SpellswordUnlock : SkillDefinition
    {
        public const byte Id = 23;
        public static readonly SpellswordUnlock Instance = new SpellswordUnlock();

        public SpellswordUnlock()
            : base(Id)
        {
            DisplayName = "Unlock Spell Thief";
            Description = "Unlock the Spellthief, and  become a martial  mage.";
            PerLevelModifier = 1f;
            BaseCost = 850;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_SpellswordUnlockLocked_Sprite";
            InputDescription = " ";
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
