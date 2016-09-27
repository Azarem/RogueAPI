using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using DS2DEngine;

namespace RogueAPI.Effects
{
    public class ImpactEffect : EffectDefinition
    {
        public static readonly ImpactEffect Instance = new ImpactEffect();

        public override float Rotation { get { return CDGMath.RandomInt(0, 360); } }

        protected ImpactEffect()
        {
            _spriteName = "ImpactEnemy_Sprite";
            _animateFlag = false;
        }

        public static void Display(Vector2 position, bool altColor = false)
        {
            Instance.Run(position, x =>
            {
                if (altColor)
                    x.Sprite.TextureColor = Color.Orange;
            });
        }
    }
}
