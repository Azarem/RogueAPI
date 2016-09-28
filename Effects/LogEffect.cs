using DS2DEngine;
using Microsoft.Xna.Framework;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class LogEffect : EffectDefinition
    {
        public static readonly LogEffect Instance = new LogEffect();

        protected static readonly TweenCommand[] _defaulCommands = new[] {
            new TweenCommand(true, 0.3f, Quad.EaseIn, "delay", "0.2", "Y", "50"),
            new TweenCommand(false, 0.2f, Linear.EaseNone, "delay", "0.3", "Opacity", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected LogEffect()
        {
            _spriteName = "Log_Sprite";
            _animationDelay = 0.05f;
            _animateFlag = true;
        }

        public static void Display(GameObj source)
        {
            Display(source.Position, source.Scale / 2f);
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
