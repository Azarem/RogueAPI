using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueAPI.Effects
{
    public class DashEffect : EffectDefinition
    {
        public static readonly DashEffect Instance = new DashEffect();

        protected DashEffect()
        {
            _spriteName = "DashFX_Sprite";
            _animateFlag = false;
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
