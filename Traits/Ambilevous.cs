using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueAPI.Game;

namespace RogueAPI.Traits
{
    public class Ambilevous : TraitDefinition
    {
        public const byte Id = 22;
        public static readonly Ambilevous Instance = new Ambilevous();

        protected Ambilevous()
            : base(Id)
        {
            this.DisplayName = "Ambilevous";
            this.Description = "You've got two left hands, and can't cast spells properly.";
            this.ProfileCardDescription = "Spells come out your back.";
            this.Rarity = 2;
        }

        private float questionTimer;

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Game.Player.PlayerEffectsUpdating += Player_PlayerEffectsUpdating;
            Event<ProjectileFireEvent>.Handler += ProjectileFired;
            questionTimer = 0.5f;
        }

        protected internal override void Deactivate(Player player)
        {
            Event<ProjectileFireEvent>.Handler -= ProjectileFired;
            Game.Player.PlayerEffectsUpdating -= Player_PlayerEffectsUpdating;
            base.Deactivate(player);
        }

        void Player_PlayerEffectsUpdating(ObjContainer player, GameTime gameTime)
        {
            if (player.CurrentSpeed == 0f)
            {
                questionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (questionTimer <= 0f)
                {
                    questionTimer = 0.4f;
                    Core.AttachEffect(EffectType.QuestionMark, player, new Vector2(player.X, player.Bounds.Top));
                }
            }
        }

        private void ProjectileFired(ProjectileFireEvent args)
        {
            if (args.Sender == Game.Player.Instance.GameObject)
            {
                var proj = args.Projectile;
                proj.AccelerationX *= -1f;
                if (!args.ProjectileDefinition.LockPosition)
                    proj.Flip = args.Sender.Flip != SpriteEffects.FlipHorizontally
                        ? SpriteEffects.FlipHorizontally
                        : SpriteEffects.None;
            }
        }

        //ProjectileManager.FireProjectile - Invert AccelerationX and Flip values
        //PlayerObj.Update - Display question mark when idle
        //PlayerObj.CastSpell - Invert projectile SourceAnchor.X, invert rotation for SpellCastEffect, invert AltX for Boomerang
    }
}
