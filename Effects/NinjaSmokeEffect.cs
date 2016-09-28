using DS2DEngine;
using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class NinjaSmokeEffect : EffectDefinition
    {
        public static readonly NinjaSmokeEffect Instance = new NinjaSmokeEffect();

        protected NinjaSmokeEffect()
        {
            _spriteName = "NinjaSmoke_Sprite";
            _animationDelay = 0.05f;
            _animateFlag = false;
        }

        public static void Display(GameObj source)
        {
            Display(source.Position, source.Scale * 2);
        }

        public static void Display(Vector2 position, Vector2 scale)
        {
            Instance.Run(position, x =>
            {
                x.Sprite.Scale = scale;
            });
        }
    }
}
