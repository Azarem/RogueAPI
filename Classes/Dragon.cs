using System;
using System.Linq;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Dragon : ClassDefinition
    {
        public const byte Id = 16;
        public static readonly Dragon Instance = new Dragon();

        private Dragon()
            : this(Id)
        {
            this.DisplayName = "Dragon";
            this.Description = "You are a man-dragon";
        }

        protected Dragon(byte id)
            : base(id)
        {
            this.HealthMultiplier = 0.4f;
            this.ManaMultiplier = 0.25f;

            this.AssignedSpells.Add(DragonFire.Instance);
        }
    }
}
