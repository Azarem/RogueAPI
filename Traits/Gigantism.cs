using DS2DEngine;
using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Gigantism : TraitDefinition
    {
        public const byte Id = 6;
        public static readonly Gigantism Instance = new Gigantism();

        protected Gigantism()
            : base(Id)
        {
            this.DisplayName = "Gigantism";
            this.Description = "You were born to be a basketball player.";
            this.ProfileCardDescription = "You are huge.";
            this.Rarity = 1;
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
            args.Player.Scale *= 1.5f;
        }
    }
}
