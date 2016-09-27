using Microsoft.Xna.Framework;

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

        public static void Display(Vector2 position, float angle, bool canRotate = false)
        {
            //Should add support for 'boss' version where angle is inverted based on obj flip
            Instance.Run(position, x =>
            {
                x.Sprite.Rotation = angle;
                x.Sprite.CanBeRotated = canRotate;
            });
        }

    }
}
