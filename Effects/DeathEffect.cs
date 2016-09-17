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
    public class DeathEffect : EffectDefinition
    {
        public static readonly DeathEffect Instance = new DeathEffect();
        private const int OffsetRange = 50;

        public override Vector2 Scale
        {
            get { return new Vector2(CDGMath.RandomFloat(0.7f, 0.8f)); }
            set { }
        }

        public override float Rotation
        {
            get { return CDGMath.RandomInt(0, 90); }
            set { }
        }

        protected DeathEffect()
        {
            SpriteName = "ExplosionBlue_Sprite";
            AnimationFlag = true;
        }

        protected override IList<TweenCommand> GetTweenCommands(EffectSpriteInstance obj)
        {
            var duration = CDGMath.RandomFloat(0.5f, 1f);
            var scale = CDGMath.RandomFloat(0f, 0.1f);

            return new TweenCommand[] {
                new TweenCommand(false, duration - 0.2f, Linear.EaseNone, "delay", "0.2", "Opacity", "0"),
                new TweenCommand(true, duration - 0.1f, Quad.EaseOut, "Rotation", CDGMath.RandomInt(145, 190).ToString()),
                new TweenCommand(false, duration, Back.EaseIn, "ScaleX", scale.ToString(), "ScaleY", scale.ToString()),
                new TweenCommand(true, duration, Quad.EaseOut,  "X", CDGMath.RandomInt(-OffsetRange, OffsetRange).ToString(), "Y", CDGMath.RandomInt(-OffsetRange, OffsetRange).ToString()) { EndHandler = new TweenEndHandler("StopAnimation") }
            };
        }

        public static void Display(Vector2 position)
        {
            for (int i = 0; i < 10; i++)
                Instance.Run(position);
        }
    }
}
