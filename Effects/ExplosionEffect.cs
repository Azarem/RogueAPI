using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Effects
{
    public class ExplosionEffect : EffectDefinition
    {
        public static readonly ExplosionEffect Instance = new ExplosionEffect();

        protected ExplosionEffect()
        {
            SpriteName = "EnemyDeathFX1_Sprite";
            Scale = new Vector2(2f);
            AnimationDelay = 1f / 30;
            AnimationFlag = false;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
