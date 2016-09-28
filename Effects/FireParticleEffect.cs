using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class FireParticleEffect : EffectDefinition
    {
        public static readonly FireParticleEffect Instance = new FireParticleEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 0.9f, Tween.EaseNone, "ScaleX", "4", "ScaleY", "4"),
            new TweenCommand(true, 0.2f, Tween.EaseNone, "Y", "0"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") },
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected FireParticleEffect()
        {
            _spriteName = "WizardFireParticle_Sprite";
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
                    float delay = CDGMath.RandomFloat(0.4f, 0.7f);

                    var cmd = _defaultCommands[2];
                    cmd.Duration = delay + 0.2f;
                    cmd.Properties[1] = CDGMath.RandomInt(-20, -5).ToString();

                    cmd = _defaultCommands[3];
                    cmd.Properties[1] = delay.ToString();
                });
        }
    }
}
