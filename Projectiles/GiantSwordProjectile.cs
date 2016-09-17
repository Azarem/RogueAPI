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
    public class GiantSwordProjectile : ProjectileDefinition
    {
        public static readonly GiantSwordProjectile Instance = new GiantSwordProjectile();

        protected GiantSwordProjectile()
        {
            SpriteName = "SpellClose_Sprite";
            SourceAnchor = new Vector2(120f, -60f);
            Speed = new Vector2(0f);
            IsWeighted = false;
            RotationSpeed = 0f;
            DestroysWithEnemy = false;
            DestroysWithTerrain = false;
            CollidesWithTerrain = false;
            Scale = new Vector2(2.5f);
            LockPosition = true;
            Lifespan = 2.1f;
            DestructionHandler = Destroy.PlayerDeflect;
        }

        public static ProjectileObj Fire(GameObj source)
        {
            var proj = Instance.Fire(source, null, null);

            proj.Opacity = 0;
            proj.Y -= 20f;
            Tween.By(proj, 0.1f, Tween.EaseNone, "Y", "20");
            Tween.To(proj, 0.1f, Tween.EaseNone, "Opacity", "1");

            return proj;
        }

    }
}
