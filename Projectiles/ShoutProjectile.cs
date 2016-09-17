using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener;

namespace RogueAPI.Projectiles
{
    public class ShoutProjectile : ProjectileDefinition
    {
        protected static readonly ShoutProjectile Instance = new ShoutProjectile();

        protected ShoutProjectile()
        {
            SpriteName = "SpellShout_Sprite";
            IsWeighted = false;
            Lifespan = 2f;
            CollidesWith1Ways = false;
            CollidesWithTerrain = false;
            DestroysWithEnemy = false;
            DestroysWithTerrain = false;
            Damage = 0;
            Scale = Vector2.One;
        }

        public override void Initialize(ProjectileObj projectile)
        {
            base.Initialize(projectile);

            projectile.Opacity = 0;
            projectile.CollisionType = Game.CollisionType.Player;
            projectile.IgnoreBoundsCheck = true;

            Tween.To(projectile, 0.2f, Tween.EaseNone, "ScaleX", "100", "ScaleY", "50");
            Tween.AddEndHandlerToLastTween(projectile, "KillProjectile");
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }

        public override void OnDestroy(ProjectileObj proj, bool hitPlayer)
        {
            base.OnDestroy(proj, hitPlayer);
        }
    }
}
