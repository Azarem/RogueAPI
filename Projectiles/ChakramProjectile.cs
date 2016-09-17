using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DS2DEngine;

namespace RogueAPI.Projectiles
{
    public class ChakramProjectile : ProjectileDefinition
    {
        public static readonly ChakramProjectile Instance = new ChakramProjectile();

        protected ChakramProjectile()
        {
            SpriteName = "SpellBoomerang_Sprite";
            Angle = new Vector2(0f);
            SourceAnchor = new Vector2(50f, -10f);
            Speed = new Vector2(790f);
            IsWeighted = false;
            RotationSpeed = 25f;
            CollidesWithTerrain = false;
            DestroysWithTerrain = false;
            DestroysWithEnemy = false;
            ShowIcon = true;
            Scale = new Vector2(3f);
            AltX = 18f;
            AltY = 0.5f;
            DestructionHandler = Destroy.Kill;
        }

        public override void Initialize(ProjectileObj projectile)
        {
            base.Initialize(projectile);

            projectile.IgnoreBoundsCheck = true;

            if (projectile.Source.Flip == SpriteEffects.FlipHorizontally)
                projectile.AltX = -projectile.AltX;
        }

        public override void Update(ProjectileObj proj, GameTime gameTime)
        {
            base.Update(proj, gameTime);

            var totalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            proj.AccelerationX -= proj.AltX * 60f * totalSeconds;
            if (proj.AltY > 0f)
            {
                proj.AltY -= totalSeconds;
                if (proj.AltY <= 0f)
                    proj.CollisionType = Game.CollisionType.GlobalDamageWall;
            }
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }

    }
}
