using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Effects
{
    public class DoubleJumpEffect : EffectDefinition
    {
        public static readonly DoubleJumpEffect Instance = new DoubleJumpEffect();

        protected DoubleJumpEffect()
        {
            SpriteName = "DoubleJumpFX_Sprite";
            AnimationFlag = false;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
