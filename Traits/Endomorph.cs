using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Endomorph : TraitDefinition
    {
        public const byte Id = 9;
        public static readonly Endomorph Instance = new Endomorph();

        protected Endomorph()
            : base(Id)
        {
            this.DisplayName = "Endomorph";
            this.Description = "You're so heavy, enemies can't knock you back.";
            this.ProfileCardDescription = "Can't get knocked back.";
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
            args.Player.Scale *= new Vector2(1.25f, 1.175f);
        }
    }
}
