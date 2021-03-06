﻿using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Hypergonadism : TraitDefinition
    {
        public const byte Id = 16;
        public static readonly Hypergonadism Instance = new Hypergonadism();

        protected Hypergonadism()
            : base(Id)
        {
            this.DisplayName = "Hypergonadism";
            this.Description = "You're perma-roided. Attacks knock enemies further.";
            this.ProfileCardDescription = "You knock enemies out of the park.";
            this.Rarity = 1;
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Event<EnemyHitEventArgs>.Handler += EnemyHitHandler;
        }

        protected internal override void Deactivate(Player player)
        {
            Event<EnemyHitEventArgs>.Handler -= EnemyHitHandler;
            base.Deactivate(player);
        }

        private void EnemyHitHandler(EnemyHitEventArgs args)
        {
            args.KnockbackForce *= 2;
        }
    }
}
