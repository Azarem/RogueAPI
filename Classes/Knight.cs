using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Knight : ClassDefinition
    {
        public const byte Id = 0;
        public static readonly Knight Instance = new Knight();

        private Knight() : this(Id) { }

        protected Knight(byte id)
            : base(id)
        {
            this.DisplayName = "Knight";
            this.Description = "Your standard hero. Pretty good at everything.";
            this.ProfileCardDescription = "100% Base stats.";

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }
    }
}
