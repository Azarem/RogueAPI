using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class TeleportBeamEffect : EffectDefinition
    {
        public static readonly TeleportBeamEffect Instance = new TeleportBeamEffect();

        protected static readonly TweenCommand[] _defaultTweens = new[]
        {
            new TweenCommand(false, 0.05f, Linear.EaseNone, "ScaleY", "1"),
            new TweenCommand(false, 2f, Linear.EaseNone) { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        protected TeleportBeamEffect()
        {
            _spriteName = "TeleporterBeam_Sprite";
            _animationDelay = 0.5f;
            _opacity = 0.8f;
            _scale = new Vector2(1f, 0f);
            _animateFlag = true;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
