using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI.Projectiles
{
    public class ProjectileDefinition : IDisposable
    {
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

        public ProjectileDefinition() { }


        public ProjectileInstance CreateInstance(GameObj source)
        {
            return new ProjectileInstance(source)
            {
                IsWeighted = this.IsWeighted,
                SpriteName = this.SpriteName,
                //Source = this.Source,
                Target = this.Target,
                SourceAnchor = this.SourceAnchor,
                AngleOffset = this.AngleOffset,
                Angle = this.Angle,
                RotationSpeed = this.RotationSpeed,
                Damage = this.Damage,
                Speed = this.Speed,
                Scale = this.Scale,
                CollidesWithTerrain = this.CollidesWithTerrain,
                Lifespan = this.Lifespan,
                ChaseTarget = this.ChaseTarget,
                TurnSpeed = this.TurnSpeed,
                FollowArc = this.FollowArc,
                StartingRotation = this.StartingRotation,
                ShowIcon = this.ShowIcon,
                DestroysWithTerrain = this.DestroysWithTerrain,
                IsCollidable = this.IsCollidable,
                DestroysWithEnemy = this.DestroysWithEnemy,
                LockPosition = this.LockPosition,
                CollidesWith1Ways = this.CollidesWith1Ways,
                DestroyOnRoomTransition = this.DestroyOnRoomTransition,
                CanBeFusRohDahed = this.CanBeFusRohDahed,
                IgnoreInvincibleCounter = this.IgnoreInvincibleCounter,
                WrapProjectile = this.WrapProjectile
            };
        }


        public virtual void Dispose()
        {
            //Source = null;
            Target = null;
        }
    }
}
