using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Projectiles
{
    public class ConfluxProjectile : ProjectileDefinition
    {
        public static readonly ConfluxProjectile Instance = new ConfluxProjectile();

        protected ConfluxProjectile()
        {
            SpriteName = "SpellBounce_Sprite";
            Angle = new Vector2(-135f);
            Speed = new Vector2(785f);
            IsWeighted = false;
            StartingRotation = -135f;
            FollowArc = false;
            RotationSpeed = 20f;
            SourceAnchor = new Vector2(-10f, -10f);
            DestroysWithTerrain = false;
            DestroysWithEnemy = false;
            CollidesWithTerrain = true;
            Scale = new Vector2(3.25f);
            ShowIcon = true;
            AltX = 3.5f;
            AltY = 0.5f;
            DestructionHandler = Destroy.FadeOutOffset;
        }

        public override void Update(ProjectileObj proj, GameTime gameTime)
        {
            base.Update(proj, gameTime);

            var totalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            proj.AccelerationX = 0f;
            proj.AccelerationY = 0f;
            proj.HeadingX = (float)Math.Cos(proj.Orientation);
            proj.HeadingY = (float)Math.Sin(proj.Orientation);
            proj.Position += (proj.Heading * (proj.CurrentSpeed * totalSeconds));

            if (proj.AltY > 0f)
            {
                proj.AltY -= totalSeconds;
                if (proj.AltY <= 0f)
                    proj.CollisionType = Game.CollisionType.GlobalDamageWall;
            }
        }

        public static ProjectileObj Fire(GameObj source, float angleOffset, Vector2 sourceAnchor)
        {
            var proj = Instance.Fire(source, null, x =>
            {
                x.InitAngleOffset = angleOffset;
                x.InitSourceAnchor = sourceAnchor;
            });

            return proj;
        }

    }
}
