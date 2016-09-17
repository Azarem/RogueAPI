using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using DS2DEngine;

namespace RogueAPI.Projectiles
{
    public class BombProjectile : ProjectileDefinition
    {
        public static BombProjectile Instance = new BombProjectile();

        protected BombProjectile()
        {
            SpriteName = "SpellTimeBomb_Sprite";
            Angle = new Vector2(-35f, -35f);
            Speed = new Vector2(500f, 500f);
            SourceAnchor = new Vector2(50f, -50f);
            IsWeighted = true;
            RotationSpeed = 0f;
            StartingRotation = 0f;
            CollidesWithTerrain = true;
            DestroysWithTerrain = false;
            CollidesWith1Ways = true;
            Scale = new Vector2(3f, 3f);
            ShowIcon = true;
            Lifespan = 20f;
            LockPosition = true;
            AltX = 1f;
            DestructionHandler = Destroy.Kill;
        }

        public override void Update(ProjectileObj proj, GameTime gameTime)
        {
            if (proj.BlinkTime >= proj.AltX && proj.AltX != 0f)
            {
                proj.Blink(Color.Red, 0.1f);
                proj.BlinkTime = proj.AltX / 1.5f;
            }

            if (proj.AltX > 0f)
            {
                proj.AltX -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (proj.AltX <= 0f)
                    DisplayExplosion(proj);
            }

            base.Update(proj, gameTime);
        }

        private void DisplayExplosion(ProjectileObj proj)
        {
            proj.IsWeighted = false;
            proj.ChangeSprite("SpellTimeBombExplosion_Sprite");
            proj.PlayAnimation(false);
            proj.IsDying = true;
            proj.CollisionType = Game.CollisionType.GlobalDamageWall;
            proj.AnimationDelay = 0.0333333351f;
            proj.Scale = new Vector2(4f);
            Tweener.Tween.RunFunction(0.5f, this, "KillProjectile");

            Effects.ExplosionEffect.Display(proj.Position);
        }

        public static ProjectileObj Fire(GameObj source)
        {
            var proj = Instance.Fire(source, null, null);

            proj.BlinkTime = proj.AltX / 1.5f;

            return proj;
        }
    }
}
