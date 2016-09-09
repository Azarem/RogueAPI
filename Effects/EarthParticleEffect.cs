using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener;

namespace RogueAPI.Effects
{
    public class EarthParticleEffect : EffectDefinition
    {
        public static readonly EarthParticleEffect Instance = new EarthParticleEffect();

        public override string SpriteName
        {
            get { return "Blossom" + CDGMath.RandomInt(1, 4) + "_Sprite"; }
            set { }
        }

        protected override IEnumerable<TweenCommand> GetTweenCommands(SpriteObj sprite)
        {
            var rotateBy = CDGMath.RandomInt(10, 45) * CDGMath.RandomPlusMinus();
            var fadeDelay = CDGMath.RandomFloat(0.4f, 0.7f);
            var offsetY = CDGMath.RandomInt(5, 20);

            return new TweenCommand[] {
                new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "1"), //Quick fade-in
                new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", fadeDelay.ToString(), "Opacity", "0") { InitialValues = new [] { 1f } }, //Quick fade-out after delay
                new TweenCommand(true, 0.2f + fadeDelay, Tween.EaseNone, "Y", offsetY.ToString()), //Offset Y until fade-out ends
                new TweenCommand(false, 0.9f, Tween.EaseNone, "ScaleX", "0.7", "ScaleY", "0.7"), //Constant scale-up
                new TweenCommand(true, 0.9f, Tween.EaseNone, "Rotation", rotateBy.ToString()) { EndHandler = new TweenEndHandler("StopAnimation") } //Offset rotation /w end handler
            };
        }

        protected EarthParticleEffect()
        {
            Scale = new Vector2(0.2f);
            Opacity = 0f;
            AnimationFlag = true;
        }

        public static void Display(GameObj source)
        {
            var bounds = source.Bounds;
            Instance.Run(new Vector2(CDGMath.RandomInt(bounds.Left, bounds.Right), CDGMath.RandomInt(bounds.Top, bounds.Bottom)));
        }
    }
}
