using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Spells;
using RogueAPI.Game;

namespace RogueAPI.Classes
{
    public class Mage : ClassDefinition
    {
        public const byte Id = 1;
        public static readonly Mage Instance = new Mage();

        private Mage() : this(Id) { }

        protected Mage(byte id)
            : base(id)
        {
            this.DisplayName = "Mage";
            this.Description = "A powerful spellcaster. Every kill gives you mana.";
            this.ProfileCardDescription = "Every kill gives you 6 mana.\nLow Str and HP.  High Int and MP.";
            this.PhysicalDamageMultiplier = 0.5f;
            this.HealthMultiplier = 0.5f;
            this.ManaMultiplier = 1.5f;
            this.MagicDamageMultiplier = 1.25f;
            this.ManaGainBonus = 6;

            this.AssignedSpells.Add(Axe.Instance);
            this.AssignedSpells.Add(Dagger.Instance);
            this.AssignedSpells.Add(TimeStop.Instance);
            this.AssignedSpells.Add(Chakram.Instance);
            this.AssignedSpells.Add(Scythe.Instance);
            this.AssignedSpells.Add(BladeWall.Instance);
            this.AssignedSpells.Add(FlameBarrier.Instance);
            this.AssignedSpells.Add(Conflux.Instance);
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
        }

        protected internal override void Deactivate(Player player)
        {
            base.Deactivate(player);
        }

    }
}
