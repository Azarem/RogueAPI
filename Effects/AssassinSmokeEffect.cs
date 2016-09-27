using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DS2DEngine;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class AssassinSmokeEffect : EffectDefinition
    {
        public static readonly AssassinSmokeEffect Instance = new AssassinSmokeEffect();

        private static readonly TweenCommand[] _defaultTweens = new TweenCommand[] {
            new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "0.5"),
            new TweenCommand(true, 1f, Quad.EaseOut, "X", "0", "Y", "0", "Rotation", "0"),
            new TweenCommand(false, 0.5f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { InitialValues = new [] { 0.5f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override Vector2 Scale { get { return new Vector2(CDGMath.RandomFloat(0.5f, 1.5f)); } }
        public override float Rotation { get { return CDGMath.RandomInt(-30, 30); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        protected AssassinSmokeEffect()
        {
            _spriteName = "ExplosionBrown_Sprite";
            _opacity = 0;
            _animateFlag = true;
        }

        public static void Display(Vector2 position, int numEffects = 10)
        {
            float currentAngle = 0f;
            float angleStep = 360f / numEffects;

            lock (_defaultTweens)
                for (int i = 0; i < numEffects; i++, currentAngle += angleStep)
                    Instance.Run(position, x =>
                    {
                        x.Sprite.TextureColor = new Color(20, 20, 20);

                        var cmd = x.TweenCommands[1];

                        var driftScale = CDGMath.AngleToVector(currentAngle);
                        cmd.Properties[1] = ((driftScale.X + CDGMath.RandomInt(-5, 5)) * CDGMath.RandomInt(20, 25)).ToString();
                        cmd.Properties[3] = ((driftScale.Y + CDGMath.RandomInt(-5, 5)) * CDGMath.RandomInt(20, 25)).ToString();
                        cmd.Properties[5] = CDGMath.RandomInt(-180, 180).ToString();
                    });
        }
    }
}
