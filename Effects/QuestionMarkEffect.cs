using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DS2DEngine;
using Tweener.Ease;
using Tweener;

namespace RogueAPI.Effects
{
    public class QuestionMarkEffect : EffectDefinition
    {
        public static readonly QuestionMarkEffect Instance = new QuestionMarkEffect();

        private static readonly TweenCommand[] _defaultTweens = new TweenCommand[] {
            new TweenCommand(false, 0.5f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 1f, Quad.EaseOut, "X", "0", "Y", "0"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0.8", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") },
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        public override Vector2 Scale { get { return new Vector2(CDGMath.RandomFloat(0.8f, 2f)); } }

        protected QuestionMarkEffect()
        {
            _spriteName = "QuestionMark_Sprite";
            _opacity = 0;
            _animateFlag = true;
        }

        public static void Display(GameObj source)
        {
            Display(new Vector2(source.X, source.Bounds.Top));
        }

        public static void Display(Vector2 position)
        {
            lock (_defaultTweens)
                Instance.Run(position, x =>
                {
                    var cmd = x.TweenCommands[1];
                    cmd.Properties[1] = CDGMath.RandomInt(-20, 20).ToString();
                    cmd.Properties[3] = CDGMath.RandomInt(-70, -50).ToString();
                });
        }
    }
}
