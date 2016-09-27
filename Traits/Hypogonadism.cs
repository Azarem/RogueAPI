using System;
using System.Linq;
using RogueAPI.Game;

namespace RogueAPI.Traits
{
    public class Hypogonadism : TraitDefinition
    {
        public const byte Id = 17;
        public static readonly Hypogonadism Instance = new Hypogonadism();

        protected Hypogonadism()
            : base(Id)
        {
            this.DisplayName = "Muscle Wk.";
            this.Description = "You have weak limbs.  Enemies won't get knocked back.";
            this.ProfileCardDescription = "You can't knock enemies back.";
            this.Rarity = 3;

            this.TraitConflicts.Add(Hypergonadism.Instance);
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
            args.KnockbackForce = 0;
        }
    }
}
