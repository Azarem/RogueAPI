using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class FountainShatterSmokeEffect : EffectDefinition
    {
        public static readonly FountainShatterSmokeEffect Instance = new FountainShatterSmokeEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(false, 0.5f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 4f, Tween.EaseNone, "Rotation", "0"),
            new TweenCommand(true, 3f, Tween.EaseNone, "X", "0", "Y", "0"),
            new TweenCommand(false, 3f, Tween.EaseNone, "ScaleX", "0", "ScaleY", "0"),
            new TweenCommand(false, 2f, Tween.EaseNone, "delay", "0", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected FountainShatterSmokeEffect()
        {
            _spriteName = "FountainShatterSmoke_Sprite";
            _opacity = 0f;
            _scale = Vector2.Zero;
            _animateFlag = true;
        }

        protected static void InitializeTweens(IList<TweenCommand> tweens, int rotationRange = 180)
        {
            var scale = CDGMath.RandomFloat(2f, 4f);

            var cmd = tweens[1];
            cmd.Properties[1] = CDGMath.RandomInt(-rotationRange, rotationRange).ToString();

            cmd = tweens[2];
            cmd.Properties[1] = CDGMath.RandomInt(-20, 20).ToString();
            cmd.Properties[3] = CDGMath.RandomInt(-50, -30).ToString();

            cmd = tweens[3];
            cmd.Properties[1] = scale.ToString();
            cmd.Properties[3] = scale.ToString();

            cmd = tweens[4];
            cmd.Properties[1] = CDGMath.RandomFloat(1f, 2f).ToString();
        }

        public static void Display(GameObj source, int numEffects = 15)
        {
            lock (_defaultCommands)
                for (int level = 0, factor = 0, range = 40; level < 3 && numEffects > 0; level++, factor += 50, numEffects /= 2, range = 180)
                {
                    float xStep = (float)(source.Width - factor) / numEffects;
                    float x = source.Bounds.Left + factor;
                    for (int i = 0; i < numEffects; i++, x += xStep)
                        Instance.Run(new Vector2(x, source.Y - (factor * 2)), s => InitializeTweens(s.TweenCommands, range));
                }
        }
    }
}
