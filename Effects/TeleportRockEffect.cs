using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class TeleportRockEffect : EffectDefinition
    {
        public static readonly TeleportRockEffect Instance = new TeleportRockEffect();

        protected static TweenCommand[] _defaultTweens = new[]
        {
            new TweenCommand(false, 0.5f, Linear.EaseNone, "delay", "0", "Opacity", "1"),
            new TweenCommand(true, 1f, Linear.EaseNone, "delay", "0", "Y", "-150"),
            new TweenCommand(false, 0.5f, Linear.EaseNone, "delay", "0", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        protected TeleportRockEffect()
        {
            _opacity = 0;
            _animateFlag = true;
        }

        public static void Display(Vector2 position)
        {
            float cumulativeDelay = 0.1f;

            lock (_defaultTweens)
                for (int i = 0; i < 5; i++)
                {
                    Instance.Run(new Vector2(position.X + CDGMath.RandomFloat(-70f, 70f), position.Y + CDGMath.RandomInt(-50, -30)), x =>
                    {
                        x.Sprite.ChangeSprite("TeleportRock" + (i + 1) + "_Sprite");

                        var cmdList = x.TweenCommands;

                        cmdList[0].Properties[1] = cumulativeDelay.ToString();
                        cmdList[1].Properties[1] = cumulativeDelay.ToString();
                        cmdList[2].Properties[1] = (cumulativeDelay + 0.5f).ToString();
                    });

                    cumulativeDelay += CDGMath.RandomFloat(0.1f, 0.3f);
                }
        }
    }
}
