using DS2DEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class BlackSmokeEffect : EffectDefinition
    {
        public static readonly BlackSmokeEffect Instance = new BlackSmokeEffect();
        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.4f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 1f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { InitialValues = new [] { 1f } },
            new TweenCommand(true, 1.5f, Quad.EaseInOut, "X", "0", "Y", "0", "Rotation", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override float Rotation
        {
            get { return CDGMath.RandomInt(-30, 30); }
            set { }
        }

        protected BlackSmokeEffect()
        {
            SpriteName = "BlackSmoke_Sprite";
            Opacity = 0;
            AnimationFlag = true;
        }

        protected override IList<TweenCommand> GetTweenCommands(EffectSpriteInstance sprite)
        {
            var tweens = _defaultCommands.Copy();
            var off = tweens[2].Clone();
            tweens[2] = off;

            off.Properties[1] = CDGMath.RandomInt(-50, 50).ToString();
            off.Properties[3] = CDGMath.RandomInt(-50, 50).ToString();
            off.Properties[5] = CDGMath.RandomInt(-45, 45).ToString();

            return tweens;
        }

        public static void Display(GameObj source)
        {
            bool invertX = source.Flip != SpriteEffects.FlipHorizontally;
            float posX = invertX ? source.Bounds.Left : source.Bounds.Right;

            for (int i = 0; i < 2; i++)
                Instance.Run(new Vector2(posX, source.Y + CDGMath.RandomInt(-40, 40)), x =>
                {
                    if (CDGMath.RandomPlusMinus() < 0)
                        x.Sprite.Flip = SpriteEffects.FlipHorizontally;

                    if (CDGMath.RandomPlusMinus() < 0)
                        x.Sprite.Flip = SpriteEffects.FlipVertically;

                    x.TweenCommands[2].Properties[1] = (invertX ? CDGMath.RandomInt(-100, -50) : CDGMath.RandomInt(50, 100)).ToString();
                    x.TweenCommands[2].Properties[3] = CDGMath.RandomInt(-100, 100).ToString();
                });
        }

        public static void Display(Vector2 position)
        {
            for (int i = 0; i < 2; i++)
                Instance.Run(position, null);
        }
    }
}
