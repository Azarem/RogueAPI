using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS2DEngine;

namespace RogueAPI.Effects
{
    public class SpellCastEffect : EffectDefinition
    {
        public static readonly SpellCastEffect Instance = new SpellCastEffect();

        protected SpellCastEffect()
        {
            SpriteName = "SpellPortal_Sprite";
            Scale = new Vector2(2f);
            OutlineWidth = 2;
            AnimationFlag = false;
        }

        public static void Display(Vector2 position, float angle, bool canRotate = false)
        {
            Instance.Run(position, x =>
            {
                x.Sprite.Rotation = angle;
                x.Sprite.CanBeRotated = canRotate;
            });
        }

    }
}
