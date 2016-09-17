using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class CrowProjectile : ProjectileDefinition
    {
        public static readonly CrowProjectile Instance = new CrowProjectile();

        protected CrowProjectile()
        {
            SpriteName = "SpellNuke_Sprite";
            Angle = new Vector2(-65f);
            Speed = new Vector2(500f);
            IsWeighted = false;
            RotationSpeed = 0f;
            CollidesWithTerrain = false;
            DestroysWithTerrain = false;
            ChaseTarget = false;
            DestroysWithEnemy = true;
            Scale = new Vector2(2f, 2f);
            //Lifespan = 99f;
            AltX = 0.25f;
            AltY = 0.05f;
            //TurnSpeed = 0.05f;
        }

        public override void Update(ProjectileObj proj, GameTime gameTime)
        {
            base.Update(proj, gameTime);

            var totalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (proj.AltY > 0f)
            {
                proj.AltY -= totalSeconds;
                if (proj.AltY <= 0f)
                {
                    //ProceduralLevelScreen currentScreen = Game.ScreenManager.CurrentScreen as ProceduralLevelScreen;
                    //if (currentScreen != null)
                    //{
                    Effects.CrowSmokeEffect.Display(proj.Position);
                    proj.AltY = 0.05f;
                    //}
                }
            }

            if (proj.AltX > 0f)
            {
                proj.AltX -= totalSeconds;
                proj.Orientation = MathHelper.WrapAngle(proj.Orientation);
            }
            else
                proj.TurnToFace(proj.Target.Position, proj.TurnSpeed, totalSeconds);

            proj.HeadingX = (float)Math.Cos(proj.Orientation);
            proj.HeadingY = (float)Math.Sin(proj.Orientation);
            proj.AccelerationX = 0f;
            proj.AccelerationY = 0f;
            proj.Position += proj.CurrentSpeed * totalSeconds * proj.Heading;

            float rotation = MathHelper.ToDegrees(proj.Orientation);
            if (proj.HeadingX <= 0f)
            {
                proj.Flip = SpriteEffects.FlipHorizontally;
                rotation = ((rotation >= 0f ? -180f : 180f) + rotation) * 60f * totalSeconds;
            }
            else
                proj.Flip = SpriteEffects.None;

            proj.Rotation = rotation;
            proj.Rotation = MathHelper.Clamp(proj.Rotation, -90f, 90f);

            if (proj.Target == null)
                proj.RunDestroyAnimation(false);
            else
            {
                var enemy = proj.Target as IKillableObj;
                if (enemy != null && enemy.IsKilled)
                    proj.RunDestroyAnimation(false);
            }
        }

        public override void OnDestroy(ProjectileObj proj, bool hitPlayer)
        {
            Effects.BlackSmokeEffect.Display(proj.Position);
            Effects.CrowFeatherEffect.Display(proj.Position);

            proj.KillProjectile();
        }

        public static ProjectileObj Fire(GameObj source, float angle, float distance)
        {
            var proj = Instance.Fire(source);
            proj.IgnoreBoundsCheck = true;
            proj.CollisionType = Game.CollisionType.Wall;
            proj.Orientation = MathHelper.ToRadians(angle);
            proj.Position = CDGMath.GetCirclePosition(angle, distance, source.Position);

            return proj;
        }

    }
}
