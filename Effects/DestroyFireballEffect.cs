using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DS2DEngine;
using Tweener.Ease;
using Tweener;

namespace RogueAPI.Effects
{
    public class DestroyFireballEffect : EffectDefinition
    {
        public static readonly DestroyFireballEffect Instance = new DestroyFireballEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(true, 1.5f, Quad.EaseOut, "X", "0", "Y", "0"),
            new TweenCommand(false, 0.5f, Tween.EaseNone, "delay", "0", "Opacity", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }
        public override Vector2 Scale { get { return new Vector2(CDGMath.RandomFloat(2f, 5f)); } }

        protected DestroyFireballEffect()
        {
            _spriteName = "SpellDamageShield_Sprite";
            _animateFlag = true;
        }

        public static void Display(Vector2 position)
        {
            float angle = 0f;
            float angleStep = 24f;

            lock (_defaultCommands)
                for (int i = 0; i < 15; i++, angle += angleStep)
                    Instance.Run(position, x =>
                    {
                        int drift = CDGMath.RandomInt(50, 200);
                        Vector2 angleFactor = CDGMath.AngleToVector(angle);

                        var cmd = _defaultCommands[0];
                        cmd.Properties[1] = (angleFactor.X * drift).ToString();
                        cmd.Properties[3] = (angleFactor.Y * drift).ToString();

                        cmd = _defaultCommands[1];
                        cmd.Properties[1] = CDGMath.RandomFloat(0.5f, 1.1f).ToString();
                    });
        }
    }
}
