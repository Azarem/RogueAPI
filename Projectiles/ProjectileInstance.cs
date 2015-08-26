using DS2DEngine;
using System;
using System.Linq;

namespace RogueAPI.Projectiles
{
    public class ProjectileInstance : ProjectileDefinition
    {
        public GameObj Source;

        public ProjectileInstance(GameObj source)
        {
            if (source == null)
                throw new Exception("Cannot create a projectile without a source");
            this.Source = source;
        }


        public ProjectileInstance Clone()
        {
            return CreateInstance(this.Source);
        }

        //public ProjectileDefinition ToDefinition()
        //{
        //    return new ProjectileDefinition()
        //    {
        //        IsWeighted = this.IsWeighted,
        //        SpriteName = this.SpriteName,
        //        //Source = this.Source,
        //        Target = this.Target,
        //        SourceAnchor = this.SourceAnchor,
        //        AngleOffset = this.AngleOffset,
        //        Angle = this.Angle,
        //        RotationSpeed = this.RotationSpeed,
        //        Damage = this.Damage,
        //        Speed = this.Speed,
        //        Scale = this.Scale,
        //        CollidesWithTerrain = this.CollidesWithTerrain,
        //        Lifespan = this.Lifespan,
        //        ChaseTarget = this.ChaseTarget,
        //        TurnSpeed = this.TurnSpeed,
        //        FollowArc = this.FollowArc,
        //        StartingRotation = this.StartingRotation,
        //        ShowIcon = this.ShowIcon,
        //        DestroysWithTerrain = this.DestroysWithTerrain,
        //        IsCollidable = this.IsCollidable,
        //        DestroysWithEnemy = this.DestroysWithEnemy,
        //        LockPosition = this.LockPosition,
        //        CollidesWith1Ways = this.CollidesWith1Ways,
        //        DestroyOnRoomTransition = this.DestroyOnRoomTransition,
        //        CanBeFusRohDahed = this.CanBeFusRohDahed,
        //        IgnoreInvincibleCounter = this.IgnoreInvincibleCounter,
        //        WrapProjectile = this.WrapProjectile
        //    };
        //}

        public override void Dispose()
        {
            Source = null;
            base.Dispose();
        }
    }
}
