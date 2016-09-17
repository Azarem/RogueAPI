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
    public class AxeProjectile : ProjectileDefinition
    {
        public static readonly AxeProjectile Instance = new AxeProjectile();

        protected AxeProjectile()
        {
            SpriteName = "SpellAxe_Sprite";
            Angle = new Vector2(-74f);
            Speed = new Vector2(1050f);
            SourceAnchor = new Vector2(50f, -50f);
            IsWeighted = true;
            RotationSpeed = 10f;
            CollidesWithTerrain = false;
            DestroysWithTerrain = false;
            DestroysWithEnemy = false;
            Scale = new Vector2(3f);
            DestructionHandler = Destroy.StopFadeOut;
        }

        public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }
    }
}
