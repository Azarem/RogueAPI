using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class IceParticleEffect : EffectDefinition
    {
        public static readonly IceParticleEffect Instance = new IceParticleEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 0.9f, Tween.EaseNone, "ScaleX", "2.5", "ScaleY", "2.5"),
            new TweenCommand(true, 0.9f, Tween.EaseNone, "Rotation", "0"),
            new TweenCommand(true, 0.2f, Tween.EaseNone, "X", "0", "Y", "0"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected IceParticleEffect()
        {
            _spriteName = "WizardIceParticle_Sprite";
            _scale = Vector2.Zero;
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
                    var delay = CDGMath.RandomFloat(0.4f, 0.7f);

                    var cmd = _defaultCommands[2];
                    cmd.Properties[1] = (CDGMath.RandomInt(90, 270) * CDGMath.RandomPlusMinus()).ToString();

                    cmd = _defaultCommands[3];
                    cmd.Duration = delay + 0.2f;
                    cmd.Properties[1] = CDGMath.RandomInt(-20, 20).ToString();
                    cmd.Properties[3] = CDGMath.RandomInt(-20, 20).ToString();

                    cmd = _defaultCommands[4];
                    cmd.Properties[1] = delay.ToString();
                });
        }
    }
}
