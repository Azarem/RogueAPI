using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class DoubleJumpEffect : EffectDefinition
    {
        public static readonly DoubleJumpEffect Instance = new DoubleJumpEffect();

        protected DoubleJumpEffect()
        {
            _spriteName = "DoubleJumpFX_Sprite";
            _animateFlag = false;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
