using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class LaserProjectile : ProjectileDefinition
    {
        public static readonly LaserProjectile Instance = new LaserProjectile();

        protected LaserProjectile()
        {
            SpriteName = "LaserSpell_Sprite";
            Angle = new Vector2(0f, 0f);
            Speed = new Vector2(0f, 0f);
            IsWeighted = false;
            IsCollidable = false;
            StartingRotation = 0f;
            FollowArc = false;
            RotationSpeed = 0f;
            DestroysWithTerrain = false;
            DestroysWithEnemy = false;
            CollidesWithTerrain = false;
            LockPosition = true;
            AltX = 1f;
            AltY = 0.5f;
            DestructionHandler = Destroy.Kill;
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, x =>
            {
                x.Opacity = 0;
                //x.X = source.CurrentRoom.X;
                x.Y = source.Y;
                //x.Scale = new Vector2(source.CurrentRoom.Width / source.Width, 0);
                x.IgnoreBoundsCheck = true;
            });
        }

        public override void Update(ProjectileObj proj, GameTime gameTime)
        {
            base.Update(proj, gameTime);
            if (proj.AltX > 0f)
            {
                proj.AltX -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                proj.Opacity = 0.9f - AltX;
                proj.ScaleY = 1f - AltX;

                if (AltX <= 0f)
                    Activate(proj);
            }
        }

        protected virtual void Activate(ProjectileObj proj)
        {
            proj.CollisionType = Game.CollisionType.GlobalDamageWall;
            proj.LifeSpan = proj.AltY;
            proj.m_elapsedLifeSpan = 0f;
            proj.IsCollidable = true;
            proj.Opacity = 1f;
        }
    }
}
