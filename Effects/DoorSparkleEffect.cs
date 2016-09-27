using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DS2DEngine;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class DoorSparkleEffect : EffectDefinition
    {
        public static readonly DoorSparkleEffect Instance = new DoorSparkleEffect();

        protected static readonly TweenCommand[] _defaultTweens = new[]
        {
            new TweenCommand(false, 0.4f, Linear.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 0.6f, Linear.EaseNone, "Rotation", "0", "Y", "-50"),
            new TweenCommand(false, 0.7f, Linear.EaseNone, "ScaleX", "0", "ScaleY", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override Vector2 Scale { get { return new Vector2(CDGMath.RandomFloat(0.3f, 0.5f)); } }
        public override float Rotation { get { return CDGMath.RandomInt(0, 90); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        protected DoorSparkleEffect()
        {
            _spriteName = "LevelUpParticleFX_Sprite";
            _opacity = 0f;
            _animateFlag = false;
        }

        public static void Display(Rectangle rect)
        {
            Display(new Vector2(CDGMath.RandomInt(rect.X, rect.X + rect.Width), CDGMath.RandomInt(rect.Y, rect.Y + rect.Height)));
        }

        public static void Display(Vector2 position)
        {
            lock (_defaultTweens)
                Instance.Run(position, x =>
                {
                    x.TweenCommands[1].Properties[1] = CDGMath.RandomInt(-45, 45).ToString();
                });
        }
    }
}
