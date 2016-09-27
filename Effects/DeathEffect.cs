using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class DeathEffect : EffectDefinition
    {
        public static readonly DeathEffect Instance = new DeathEffect();

        protected static readonly TweenCommand[] _defaultTweens = new[] {
            new TweenCommand(false, 0f, Back.EaseIn, "ScaleX", "0", "ScaleY", "0"),
            new TweenCommand(true, 0f, Quad.EaseOut,  "X", "0", "Y", "0"),
            new TweenCommand(true, 0.1f, Quad.EaseOut, "Rotation", "0"),
            new TweenCommand(false, 0.2f, Linear.EaseNone, "delay", "0.2", "Opacity", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override Vector2 Scale { get { return new Vector2(CDGMath.RandomFloat(0.7f, 0.8f)); } }
        public override float Rotation { get { return CDGMath.RandomInt(0, 90); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        protected DeathEffect()
        {
            _spriteName = "ExplosionBlue_Sprite";
            _animateFlag = true;
        }

        protected static void Initialize(EffectDisplayEvent evt)
        {
            float duration = CDGMath.RandomFloat(0.5f, 1f);
            float scaleTo = CDGMath.RandomFloat(0f, 0.1f);

            var cmd = _defaultTweens[0];
            cmd.Duration = duration;
            cmd.Properties[1] = scaleTo.ToString();
            cmd.Properties[3] = scaleTo.ToString();

            cmd = _defaultTweens[1];
            cmd.Duration = duration;
            cmd.Properties[1] = CDGMath.RandomInt(-50, 50).ToString();
            cmd.Properties[3] = CDGMath.RandomInt(-50, 50).ToString();

            cmd = _defaultTweens[2];
            cmd.Duration = duration - 0.1f;
            cmd.Properties[1] = CDGMath.RandomInt(145, 190).ToString();

            cmd = _defaultTweens[3];
            cmd.Duration = duration - 0.2f;
        }

        public static void Display(Vector2 position, int numEffects = 10)
        {
            lock (_defaultTweens)
                for (int i = 0; i < numEffects; i++)
                    Instance.Run(position, Initialize);
        }
    }
}
