using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Tweener;

namespace RogueAPI.Projectiles
{
    public class ProjectileObj : PhysicsObj
    {
        public ProjectileObj(string spriteName)
            : base(spriteName)
        {

        }

        private float m_elapsedLifeSpan;
        private Color m_blinkColour = Color.White;
        private float m_blinkTimer;

        public float AltX { get; set; }
        public float AltY { get; set; }
        public GameObj AttachedIcon { get; set; }
        public float BlinkTime { get; set; }
        public bool CanBeFusRohDahed { get; set; }
        public bool ChaseTarget { get; set; }
        public bool CollidesWith1Ways { get; set; }
        public bool CollidesWithTerrain { get; set; }
        public float LifeSpan { get; set; }
        public GameObj Source { get; set; }
        public GameObj Target { get; set; }
        public bool DestroysWithTerrain { get; set; }
        public bool DestroysWithEnemy { get; set; }
        public bool FollowArc { get; set; }
        public bool DestroyOnRoomTransition { get; set; }
        public bool WrapProjectile { get; set; }
        public bool IgnoreInvincibleCounter { get; set; }
        public bool ShowIcon { get; set; }
        public int Damage { get; set; }
        public float RotationSpeed { get; set; }
        public bool IsDying { get; set; }
        public bool IsAlive { get; set; }
        public bool IgnoreBoundsCheck { get; set; }
        public bool GamePaused { get; set; }
        public int Spell { get; set; }

        public void Reset()
        {
            Source = null;
            CollidesWithTerrain = true;
            DestroysWithTerrain = true;
            DestroysWithEnemy = true;
            IsCollidable = true;
            IsWeighted = true;
            IsDying = false;
            IsAlive = true;
            m_elapsedLifeSpan = 0f;
            Rotation = 0f;
            TextureColor = Color.White;
            Spell = 0;
            AltY = 0f;
            AltX = 0f;
            BlinkTime = 0f;
            IgnoreBoundsCheck = false;
            Scale = Vector2.One;
            DisableHitboxUpdating = false;
            m_blinkColour = Color.White;
            m_blinkTimer = 0f;
            AccelerationYEnabled = true;
            AccelerationXEnabled = true;
            GamePaused = false;
            DestroyOnRoomTransition = true;
            CanBeFusRohDahed = true;
            Flip = SpriteEffects.None;
            IgnoreInvincibleCounter = false;
            WrapProjectile = false;
            DisableCollisionBoxRotations = true;
            Tween.StopAllContaining(this, false);
        }

        public void UpdateHeading()
        {
            if (ChaseTarget && Target != null)
            {
                TurnToFace(Target.Position, TurnSpeed, 0.0166666675f);
                HeadingX = (float)Math.Cos(Orientation);
                HeadingY = (float)Math.Sin(Orientation);
            }
        }

        private void TurnToFace(Vector2 facePosition, float turnSpeed, float elapsedSeconds)
        {
            float angle = MathHelper.WrapAngle((float)Math.Atan2(facePosition.Y - Position.Y, facePosition.X - Position.X) - Orientation);
            float limit = turnSpeed * 60f * elapsedSeconds;
            angle = MathHelper.Clamp(angle, -limit, limit);
            Orientation = MathHelper.WrapAngle(Orientation + angle);
        }

        public void KillProjectile()
        {
            IsAlive = false;
            IsDying = false;
        }
    }
}
