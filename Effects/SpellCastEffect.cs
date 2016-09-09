using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS2DEngine;

namespace RogueAPI.Effects
{
    public class SpellCastEffect : EffectDefinition<float>
    {
        public static readonly SpellCastEffect Instance = new SpellCastEffect();

        protected SpellCastEffect()
        {
            SpriteName = "SpellPortal_Sprite";
            Scale = new Vector2(2f, 2f);
            OutlineWidth = 2;
            AnimationFlag = false;
        }

        protected override SpriteObj CreateSprite(Vector2 position, float angle)
        {
            var sprite = base.CreateSprite(position, angle);

            sprite.Rotation = angle;

            return sprite;
        }

        public static void Display(Vector2 position, float angle)
        {
            Instance.Run(position, angle);
        }

    }
}
