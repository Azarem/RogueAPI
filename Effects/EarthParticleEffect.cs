using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class EarthParticleEffect : EffectDefinition
    {
        public static readonly EarthParticleEffect Instance = new EarthParticleEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 0.2f, Tween.EaseNone, "Y", "0"),
            new TweenCommand(false, 0.9f, Tween.EaseNone, "ScaleX", "0.7", "ScaleY", "0.7"),
            new TweenCommand(true, 0.9f, Tween.EaseNone, "Rotation", "0"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") }, //Quick fade-out after delay
        };

        public override string SpriteName { get { return "Blossom" + CDGMath.RandomInt(1, 4) + "_Sprite"; } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected EarthParticleEffect()
        {
            _scale = new Vector2(0.2f);
            _opacity = 0f;
            _animateFlag = true;
        }

        public static void Display(GameObj source)
        {
            var bounds = source.Bounds;
            Display(new Vector2(CDGMath.RandomInt(bounds.Left, bounds.Right), CDGMath.RandomInt(bounds.Top, bounds.Bottom)));
        }

        public static void Display(Vector2 position)
        {
            lock (_defaultCommands)
                Instance.Run(position, x =>
                {
                    var fadeDelay = CDGMath.RandomFloat(0.4f, 0.7f);

                    var cmd = _defaultCommands[1];
                    cmd.Duration = 0.2f + fadeDelay;
                    cmd.Properties[1] = CDGMath.RandomInt(5, 20).ToString();

                    cmd = _defaultCommands[3];
                    cmd.Properties[1] = (CDGMath.RandomInt(10, 45) * CDGMath.RandomPlusMinus()).ToString();

                    cmd = _defaultCommands[4];
                    cmd.Properties[1] = fadeDelay.ToString();
                });
        }
    }
}
