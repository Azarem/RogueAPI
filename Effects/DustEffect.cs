using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class DustEffect : EffectDefinition
    {
        public static readonly DustEffect Instance = new DustEffect();
        private const int OffsetRange = 30;
        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.2f, Linear.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 0.5f, Linear.EaseNone, "delay", "0.2", "Opacity", "0") { InitialValues = new [] { 1f } },
            new TweenCommand(true, 0.7f, Linear.EaseNone, "Rotation", "180"),
            new TweenCommand(true, 0.7f, Quad.EaseOut, "X", "0", "Y", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };


        public override float Rotation
        {
            get { return CDGMath.RandomInt(0, 270); }
            set { }
        }

        protected DustEffect()
        {
            SpriteName = "ExplosionBrown_Sprite";
            Opacity = 0;
            Scale = new Vector2(0.8f);
            AnimationFlag = true;
        }

        protected override IList<TweenCommand> GetTweenCommands(EffectSpriteInstance obj)
        {
            TweenCommand offset;
            var tweens = _defaultCommands.Copy();
            tweens[3] = offset = tweens[3].Clone();

            offset.Properties[1] = CDGMath.RandomInt(-OffsetRange, OffsetRange).ToString();
            offset.Properties[3] = CDGMath.RandomInt(-OffsetRange, OffsetRange).ToString();

            return tweens;
        }

        public static void Display(GameObj source)
        {
            Display(new Vector2(source.X, source.Bounds.Bottom));
        }
        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
