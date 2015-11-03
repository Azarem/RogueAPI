namespace RogueAPI.Skills
{
    public class MageUp : SkillDefinition
    {
        public const byte Id = 26;
        public static readonly MageUp Instance = new MageUp();

        public MageUp()
            : base(Id)
        {
            DisplayName = "Upgrade Mage";
            Description = "Unlock the latent powers of the Mage and transform them into the all powerful Archmage";
            PerLevelModifier = 1f;
            BaseCost = 300;
            CostIncrement = 0;
            MaxLevel = 1;
            Icon = "Icon_WizardUpLocked_Sprite";
            InputDescription = string.Concat("Press [Input:", (byte)13, "] to switch spells");
            UnitText = " hp";
            DisplayStat = true;
        }
    }
}
