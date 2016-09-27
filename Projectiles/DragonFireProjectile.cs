using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class DragonFireProjectile : ProjectileDefinition
    {
        public static readonly DragonFireProjectile Instance = new DragonFireProjectile();

        protected DragonFireProjectile()
        {
            SpriteName = "TurretProjectile_Sprite";
            Angle = Vector2.Zero;
            SourceAnchor = new Vector2(50f, 0f);
            Speed = new Vector2(1100f);
            Lifespan = 0.35f;
            IsWeighted = false;
            RotationSpeed = 0f;
            CollidesWithTerrain = true;
            DestroysWithTerrain = true;
            Scale = new Vector2(2.5f);
            AltX = 0.35f;
            AltY = 0f;
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }
    }
}
