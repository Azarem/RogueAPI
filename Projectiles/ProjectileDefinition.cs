using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Projectiles
{
    public class ProjectileDefinition : IDisposable
    {
        public static Func<ProjectileObj> AllocateProjectile;

        public bool IsWeighted;
        public string SpriteName;
        //public GameObj Source;
        public GameObj Target;
        public Vector2 SourceAnchor;
        public float AngleOffset;
        public Vector2 Angle;
        public float RotationSpeed;
        public int Damage;
        public Vector2 Speed;
        public Vector2 Scale = new Vector2(1f, 1f);
        public bool CollidesWithTerrain = true;
        public bool DestroysWithTerrain = true;
        public float Lifespan = 10f;
        public float TurnSpeed = 10f;
        public bool ChaseTarget;
        public bool FollowArc;
        public float StartingRotation;
        public bool ShowIcon = true;
        public bool IsCollidable = true;
        public bool DestroysWithEnemy = true;
        public bool LockPosition;
        public bool CollidesWith1Ways;
        public bool DestroyOnRoomTransition = true;
        public bool CanBeFusRohDahed = true;
        public bool IgnoreInvincibleCounter;
        public bool WrapProjectile;
        public float AltX;
        public float AltY;

        protected Action<ProjectileObj, bool> DestructionHandler;

        //public virtual string SpriteName { get { return spriteName; } set { spriteName = value; } }
        //public virtual Vector2 SourceAnchor { get { return sourceAnchor; } set { sourceAnchor = value; } }
        //public virtual object Target { get { return target; } set { target = value; } }
        //public virtual Vector2 Speed { get { return speed; } set { speed = value; } }
        //public virtual bool IsWeighted { get { return isWeigted; } set { isWeigted = value; } }
        //public virtual float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }
        //public virtual int Damage { get { return damage; } set { damage = value; } }
        //public virtual float AngleOffset { get { return angleOffset; } set { angleOffset = value; } }
        //public virtual bool CollidesWithTerrain { get { return collidesWithTerrain; } set { collidesWithTerrain = value; } }
        //public virtual bool DestroysWithTerrain { get { return destroysWithTerrain; } set { destroysWithTerrain = value; } }
        //public virtual Vector2 Scale { get { return scale; } set { scale = value; } }
        //public virtual bool ShowIcon { get { return showIcon; } set { showIcon = value; } }

        public ProjectileDefinition()
        {
            SpriteName = "BoneProjectile_Sprite";
            SourceAnchor = Vector2.Zero;
            Speed = new Vector2(0f, 0f);
            IsWeighted = false;
            RotationSpeed = 0f;
            Damage = 0;
            AngleOffset = 0f;
            CollidesWithTerrain = false;
            Scale = Vector2.One;
            ShowIcon = false;
            DestructionHandler = Destroy.Explosion;
        }

        protected ProjectileObj Fire(GameObj source, GameObj target = null, Action<ProjectileObj> postInit = null)
        {
            if (source == null)
                throw new InvalidOperationException("Projectile must have a source");

            var projectile = AllocateProjectile();
            projectile.Initialize(this, source, target);
            postInit?.Invoke(projectile);
            Initialize(projectile);

            return projectile;
        }

        public virtual void Initialize(ProjectileObj projectile)
        {
            projectile.Prepare();
        }

        public virtual void Update(ProjectileObj proj, GameTime gameTime)
        {
        }

        public virtual void OnDestroy(ProjectileObj proj, bool hitPlayer)
        {
            DestructionHandler?.Invoke(proj, hitPlayer);
        }

        public virtual bool OnCollision(ProjectileObj proj, PhysicsObjContainer target, bool targetIsPlayer, Vector2 knockbackAmount)
        {
            return true;
        }

        public virtual void Dispose()
        {
            //Source = null;
            Target = null;
        }

        protected static class Destroy
        {
            public static void Explosion(ProjectileObj proj, bool hitPlayer)
            {
                string newSprite = proj.SpriteName.Replace("_", "Explosion_");
                proj.ChangeSprite(newSprite);
                proj.AnimationDelay = 0.0333333351f;
                proj.PlayAnimation(false);
                proj.IsWeighted = false;
                proj.IsCollidable = false;

                if (newSprite != "EnemySpearKnightWaveExplosion_Sprite" && newSprite != "WizardIceProjectileExplosion_Sprite")
                    proj.Rotation = 0f;

                Tween.RunFunction(0.5f, proj, "KillProjectile");
            }

            public static void Kill(ProjectileObj proj, bool hitPlayer)
            {
                proj.KillProjectile();
            }

            public static void FadeOutOffset(ProjectileObj proj, bool hitPlayer)
            {
                Tween.StopAllContaining(proj, false);
                proj.IsCollidable = false;
                Tween.By(proj, 0.3f, Linear.EaseNone, "X", CDGMath.RandomInt(-50, 50).ToString(), "Y", CDGMath.RandomInt(-100, 100).ToString());
                Tween.To(proj, 0.3f, Linear.EaseNone, "Opacity", "0");
                Tween.AddEndHandlerToLastTween(proj, "KillProjectile");
            }

            public static void PlayerDeflect(ProjectileObj proj, bool hitPlayer)
            {
                if (hitPlayer)
                {
                    Tween.By(proj, 0.3f, Linear.EaseNone, "X", CDGMath.RandomInt(-50, 50).ToString(), "Y", CDGMath.RandomInt(-100, -50).ToString(), "Rotation", "270");
                    Tween.To(proj, 0.3f, Linear.EaseNone, "Opacity", "0");
                }
                else
                {
                    proj.IsWeighted = false;
                    proj.IsCollidable = false;
                    Tween.To(proj, 0.3f, Linear.EaseNone, "delay", "0.3", "Opacity", "0");
                }

                Tween.AddEndHandlerToLastTween(proj, "KillProjectile");
            }

            public static void StopFadeOut(ProjectileObj proj, bool hitPlayer)
            {
                proj.IsCollidable = false;
                proj.AccelerationX = 0f;
                proj.AccelerationY = 0f;
                Tween.To(proj, 0.3f, Tween.EaseNone, "Opacity", "0");
                Tween.AddEndHandlerToLastTween(proj, "KillProjectile");
            }

            public static void FadeOut(ProjectileObj proj, bool hitPlayer)
            {
                Tween.To(proj, 0.2f, Tween.EaseNone, "Opacity", "0");
                Tween.AddEndHandlerToLastTween(proj, "KillProjectile");
            }
        }
    }
}
