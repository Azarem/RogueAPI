using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener;
using Tweener.Ease;
using DS2DEngine;

namespace RogueAPI.Effects
{
    public class CrowSmokeEffect : EffectDefinition
    {
        public static CrowSmokeEffect Instance = new CrowSmokeEffect();

        protected static readonly TweenCommand[] _defaultTweens = new TweenCommand[] {
            new TweenCommand(false, 0.2f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 0.5f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { InitialValues = new []{ 1f } },
            new TweenCommand(true, 1f, Quad.EaseInOut, "X", "0", "Y", "0", "Rotation", "0") {EndHandler = new TweenEndHandler("StopAnimation") },
        };

        public override float Rotation
        {
            get { return CDGMath.RandomInt(-30, 30); }
            set { }
        }

        protected CrowSmokeEffect()
        {
            SpriteName = "BlackSmoke_Sprite";
            Scale = new Vector2(0.7f);
            Opacity = 0f;
            AnimationFlag = true;
        }

        protected override IList<TweenCommand> GetTweenCommands(EffectSpriteInstance obj)
        {
            var list = _defaultTweens.Copy();
            var offset = list[2].Clone();
            list[2] = offset;

            offset.Properties[1] = CDGMath.RandomInt(50, 100).ToString();
            offset.Properties[3] = CDGMath.RandomInt(-100, 100).ToString();
            offset.Properties[5] = CDGMath.RandomInt(-45, 45).ToString();

            return list;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(new Vector2(position.X + CDGMath.RandomInt(-40, 40), position.Y + CDGMath.RandomInt(-40, 40)));
        }

    }
}
