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
    public class FlameBarrierProjectile : ProjectileDefinition
    {
        public static readonly FlameBarrierProjectile Instance = new FlameBarrierProjectile();

        protected FlameBarrierProjectile()
        {
            SpriteName = "SpellDamageShield_Sprite";
            Angle = new Vector2(-65f);
            Speed = new Vector2(3.25f);
            //Target = player,
            IsWeighted = false;
            RotationSpeed = 0f;
            CollidesWithTerrain = false;
            DestroysWithTerrain = false;
            DestroysWithEnemy = false;
            Scale = new Vector2(3f, 3f);
            DestroyOnRoomTransition = false;
            Lifespan = 9999f;
            AltX = 0f;
            AltY = 200f;
            DestructionHandler = Destroy.FadeOut;
        }

        public override void Initialize(ProjectileObj projectile)
        {
            base.Initialize(projectile);

            projectile.IgnoreBoundsCheck = true;
            projectile.AccelerationXEnabled = false;
            projectile.AccelerationYEnabled = false;
        }

        public override void Update(ProjectileObj proj, GameTime gameTime)
        {
            base.Update(proj, gameTime);

            proj.AltX += proj.CurrentSpeed * 60f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            proj.Position = CDGMath.GetCirclePosition(proj.AltX, proj.AltY, proj.Target.Position);
        }

        public static ProjectileObj Fire(GameObj source, int index, int total, int distance)
        {
            var proj = Instance.Fire(source, source, x =>
            {
                x.AltX = 360f / total * index;
                x.AltY = distance;
            });
            return proj;
        }
    }
}
