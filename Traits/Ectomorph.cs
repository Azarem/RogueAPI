using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Ectomorph : TraitDefinition
    {
        public const byte Id = 10;
        public static readonly Ectomorph Instance = new Ectomorph();

        protected Ectomorph()
            : base(Id)
        {
            this.DisplayName = "Ectomorph";
            this.Description = "You're skinny, so every hit sends you flying.";
            this.ProfileCardDescription = "Hits send you flying.";
            this.Rarity = 2;

            this.TraitConflicts.Add(Gigantism.Instance);
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Event<LevelEnterEventArgs>.Handler += LevelScreenEntered;
        }

        protected internal override void Deactivate(Player player)
        {
            Event<LevelEnterEventArgs>.Handler -= LevelScreenEntered;
            base.Deactivate(player);
        }

        private void LevelScreenEntered(LevelEnterEventArgs args)
        {
            args.Player.Scale *= new Vector2(0.825f, 1.15f);
        }
    }
}
