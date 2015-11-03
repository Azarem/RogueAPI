using System;
using System.Linq;
using RogueAPI.Spells;
using DS2DEngine;
using RogueAPI.Game;
using Microsoft.Xna.Framework;

namespace RogueAPI.Classes
{
    public class Barbarian : ClassDefinition
    {
        public const byte Id = 2;
        public static readonly Barbarian Instance = new Barbarian();

        private Barbarian()
            : this(Id)
        {
            this.DisplayName = "Barbarian";
            this.Description = "A walking tank. This hero can take a beating.";
            this.ProfileCardDescription = "Huge HP.  Low Str and MP.";
        }

        protected Barbarian(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 1.5f;
            this.ManaMultiplier = 0.5f;

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
        }

        private ObjContainer player;

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Game.Player.Ability = Abilities.FahRoDus.Instance;
        }

        protected internal override void Deactivate(Player player)
        {
            Game.Player.Ability = null;
            base.Deactivate(player);
        }

    }
}
