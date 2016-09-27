using System.Collections.Generic;
using DS2DEngine;
using Microsoft.Xna.Framework;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class InverseEmitEffect : EffectDefinition
    {
        public static readonly InverseEmitEffect Instance = new InverseEmitEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(false, 0f, Linear.EaseNone, "ScaleX", "2", "ScaleY", "2"),
            new TweenCommand(false, 0f, Quad.EaseInOut, "delay", "0", "X", "0", "Y", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected InverseEmitEffect()
        {
            _spriteName = "Blank_Sprite";
            _scale = Vector2.Zero;
            _animateFlag = true;
        }

        public static void Display(Vector2 position, int numSprites = 30, float duration = 0.4f)
        {
            float step = duration / numSprites;
            float currentDuration = 0f;

            lock (_defaultCommands)
                for (int i = 0; i < numSprites; i++)
                {
                    Instance.Run(new Vector2(position.X + CDGMath.RandomInt(-100, 100), position.Y + CDGMath.RandomInt(-100, 100)), x =>
                    {
                        x.Sprite.TextureColor = Color.Black;

                        var cmd = _defaultCommands[0];
                        cmd.Duration = currentDuration;

                        cmd = _defaultCommands[1];
                        cmd.Duration = duration - currentDuration;
                        cmd.Properties[1] = currentDuration.ToString();
                        cmd.Properties[3] = position.X.ToString();
                        cmd.Properties[5] = position.Y.ToString();
                    });

                    currentDuration += step;
                }
        }


    }
}
