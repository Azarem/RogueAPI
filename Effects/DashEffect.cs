using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS2DEngine;
using Microsoft.Xna.Framework.Graphics;

namespace RogueAPI.Effects
{
    public class DashEffect : EffectDefinition
    {
        public static readonly DashEffect Instance = new DashEffect();

        protected DashEffect()
        {
            SpriteName = "DashFX_Sprite";
            AnimationFlag = false;
        }

        public static void Display(Vector2 position, bool flip)
        {
            Instance.Run(position, x =>
            {
                if (flip)
                    x.Sprite.Flip = SpriteEffects.FlipHorizontally;
            });
        }
    }
}
