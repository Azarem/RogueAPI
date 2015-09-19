using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;

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

        protected internal override void Activate()
        {
            base.Activate();
            Game.Player.PlayerEffectsUpdating += Player_PlayerEffectsUpdating;
            questionTimer = 0.5f;
        }

        protected internal override void Deactivate()
        {
            Game.Player.PlayerEffectsUpdating -= Player_PlayerEffectsUpdating;
            base.Deactivate();
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

        //ProjectileManager.FireProjectile - Invert AccelerationX and Flip values
        //PlayerObj.Update - Display question mark when idle
        //PlayerObj.CastSpell - Invert projectile SourceAnchor.X, invert rotation for SpellCastEffect, invert AltX for Boomerang
    }
}
