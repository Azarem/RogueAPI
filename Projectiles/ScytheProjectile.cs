using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class ScytheProjectile : ProjectileDefinition
    {
        public static readonly ScytheProjectile Instance = new ScytheProjectile();

        protected ScytheProjectile()
        {
            SpriteName = "SpellDualBlades_Sprite";
            Angle = new Vector2(-55f);
            SourceAnchor = new Vector2(50f, 30f);
            Speed = new Vector2(1000f);
            IsWeighted = false;
            RotationSpeed = 30f;
            CollidesWithTerrain = false;
            DestroysWithTerrain = false;
            DestroysWithEnemy = false;
            Scale = new Vector2(2f);
        }

        public static ProjectileObj Fire(GameObj source, bool alt = false)
        {
            return Instance.Fire(source, null, x =>
            {
                if (alt)
                {
                    x.InitAngleRange = new Vector2(-10f);
                    x.InitSourceAnchor = new Vector2(50f, -30f);
                    x.RotationSpeed = -20f;
                }
            });
        }
    }
}
