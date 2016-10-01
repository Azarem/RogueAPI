using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueAPI.Effects
{
    public class SpellCastEffect : EffectDefinition
    {
        public static readonly SpellCastEffect Instance = new SpellCastEffect();

        protected SpellCastEffect()
        {
            _spriteName = "SpellPortal_Sprite";
            _scale = new Vector2(2f);
            _outlineWidth = 2;
            _animateFlag = false;
        }

        public static void Display(GameObj source, float angle, bool canRotate = false, bool megaSpell = false)
        {
            Display(source.Position, angle, canRotate, source.Flip == SpriteEffects.None, megaSpell);
        }

        public static void Display(Vector2 position, float angle, bool canRotate = false, bool flip = false, bool megaSpell = false)
        {
            //Should add support for 'boss' version where angle is inverted based on obj flip
            Instance.Run(position, x =>
            {
                x.Sprite.Rotation = flip ? -angle : angle;
                x.Sprite.CanBeRotated = canRotate;
                if (megaSpell)
                    x.Sprite.TextureColor = Color.Red;
            });
        }

    }
}
