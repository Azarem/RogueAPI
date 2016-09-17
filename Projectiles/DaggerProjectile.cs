using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class DaggerProjectile : ProjectileDefinition
    {
        public static readonly DaggerProjectile Instance = new DaggerProjectile();

        protected DaggerProjectile()
        {
            SpriteName = "SpellDagger_Sprite";
            Angle = Vector2.Zero;
            SourceAnchor = new Vector2(50f, 0f);
            Speed = new Vector2(1750f);
            IsWeighted = false;
            RotationSpeed = 0f;
            CollidesWithTerrain = true;
            DestroysWithTerrain = true;
            Scale = new Vector2(2.5f);
            DestructionHandler = Destroy.PlayerDeflect;
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }
    }
}
