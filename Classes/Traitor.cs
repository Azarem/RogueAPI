using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Traitor : ClassDefinition
    {
        public const byte Id = 17;
        public static readonly Traitor Instance = new Traitor();

        private Traitor()
            : this(Id)
        {
            this.DisplayName = "Traitor";
            this.Description = "Fountain text here";
        }

        protected Traitor(byte id)
            : base(id)
        {
            this.HealthMultiplier = 0.7f;
            this.ManaMultiplier = 0.7f;

            this.AssignedSpells.Add(RapidDagger.Instance);
        }
    }
}
