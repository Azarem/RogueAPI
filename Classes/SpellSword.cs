using System;
using System.Linq;
using RogueAPI.Game;
using RogueAPI.Spells;
using DS2DEngine;
using Microsoft.Xna.Framework;

namespace RogueAPI.Classes
{
    public class SpellSword : ClassDefinition
    {
        public const byte Id = 6;
        public static readonly SpellSword Instance = new SpellSword();

        private float _sparkleTimer = 0;

        private SpellSword()
            : this(Id)
        {
            this.DisplayName = "Spellthief";
            this.Description = "A hero for experts. Hit enemies to restore mana.";
            this.ProfileCardDescription = "30% of damage dealt is converted into mana.\nLow Str, HP, and MP.";
        }

        protected SpellSword(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 0.75f;
            this.ManaMultiplier = 0.4f;

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
            this.AssignedSpells.Add(SpellDefinition.GetById(11));
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Player.PlayerEffectsUpdating += PlayerEffectsUpdating;
            Event<EnemyHitEventArgs>.Handler += EnemyHitHandler;
            _sparkleTimer = 0.2f;
        }

        protected internal override void Deactivate(Player player)
        {
            Event<EnemyHitEventArgs>.Handler -= EnemyHitHandler;
            Player.PlayerEffectsUpdating -= PlayerEffectsUpdating;
            base.Deactivate(player);
        }

        private void PlayerEffectsUpdating(ObjContainer player, GameTime gameTime)
        {
            _sparkleTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_sparkleTimer <= 0)
            {
                _sparkleTimer = 0.2f;
                Effects.ChestSparkleEffect.Display(player.Position);
                Effects.ChestSparkleEffect.Display(player.Position);
            }
        }

        private void EnemyHitHandler(EnemyHitEventArgs args)
        {
            if (args.WasPlayer)
            {
                var manaGain = (int)(args.Damage * 0.3f);
                var manaStat = Player.Instance.GetStatObject(Stats.ManaStat.Id);

                manaStat.CurrentValue += manaGain;

                var player = Player.Instance.GameObject;
                Core.DisplayNumberString(manaGain, "mp", Color.RoyalBlue, new Vector2(player.X, player.Bounds.Top - 30));
            }
        }
    }
}
