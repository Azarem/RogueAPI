using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class DisplacerProjectile : ProjectileDefinition
    {
        public static readonly DisplacerProjectile Instance = new DisplacerProjectile();

        protected DisplacerProjectile()
        {
            SourceAnchor = new Vector2(0f);
            SpriteName = "SpellDisplacer_Sprite";
            Angle = new Vector2(0f);
            Speed = Vector2.Zero;
            IsWeighted = false;
            RotationSpeed = 0f;
            CollidesWithTerrain = true;
            DestroysWithTerrain = false;
            CollidesWith1Ways = true;
            Scale = new Vector2(2f);
            DestructionHandler = Destroy.FadeOut;
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }
    }
}
