namespace RogueAPI.Skills
{
    public class SpellswordUp : SkillDefinition
    {
        public const byte Id = 32;
        public static readonly SpellswordUp Instance = new SpellswordUp();

        public SpellswordUp()
            : base(Id)
        {
            DisplayName = "Upgrade Spell Thief";
            Description = "Ride the vortexes of magic, and turn your Spellthiefs into Spellswords.";
            PerLevelModifier = 1f;
            BaseCost = 1500;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_SpellswordUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to cast empowered spells");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
