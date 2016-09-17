namespace RogueAPI.Spells
{
    public class Translocator : SpellDefinition
    {
        public const byte Id = 6;
        public static readonly Translocator Instance = new Translocator();

        private Translocator() : this(Id) { }

        protected Translocator(byte id)
            : base(id)
        {
            displayName = "Quantum Translocator";
            icon = "TranslocatorIcon_Sprite";
            description = string.Format("[Input:{0}]  Drops and teleports to your shadow.", (int)Game.InputKeys.PlayerSpell1);
            miscValue1 = 0f;
            miscValue2 = 0f;
            rarity = 3;
            manaCost = 5;
            damageMultiplier = 0f;
        }
    }
}
