using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class DragonFireNeoProjectile : DragonFireProjectile
    {
        new public static DragonFireNeoProjectile Instance = new DragonFireNeoProjectile();

        protected DragonFireNeoProjectile()
        {
            Speed = new Vector2(1750f);
            Lifespan = 0.75f;
            Scale = new Vector2(2.75f);
            WrapProjectile = true;
            AltX = 0.75f;
        }

        new public static ProjectileObj Fire(GameObj source)
        {
            return Instance.Fire(source, null, null);
        }
    }
}
