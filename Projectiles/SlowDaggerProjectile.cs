using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Projectiles
{
    public class SlowDaggerProjectile : DaggerProjectile
    {
        new public static readonly SlowDaggerProjectile Instance = new SlowDaggerProjectile();

        protected SlowDaggerProjectile()
        {
            Speed = new Vector2(900f);
            //Damage = this.Damage;
            CollidesWithTerrain = false;
            Scale = new Vector2(3.5f);
            FollowArc = true;
            IgnoreInvincibleCounter = true;
        }

        public static ProjectileObj Fire(GameObj source, bool randomize)
        {
            return Instance.Fire(source, null, x =>
            {
                if (randomize)
                    x.InitAngleOffset = CDGMath.RandomInt(-8, 8);
                x.TextureColor = Color.CadetBlue;
            });
        }
    }
}
