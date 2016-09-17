using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class CrowFeatherEffect : EffectDefinition
    {
        public static readonly CrowFeatherEffect Instance = new CrowFeatherEffect();

        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 1f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { InitialValues = new [] { 1f } },
            new TweenCommand(true, 1.5f, Quad.EaseInOut, "X", "0", "Y", "0", "Rotation", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override float Rotation
        {
            get { return CDGMath.RandomInt(-30, 30); }
            set { }
        }

        protected CrowFeatherEffect()
        {
            SpriteName = "CrowFeather_Sprite";
            Scale = new Vector2(2f);
            Opacity = 0f;
            AnimationFlag = true;
        }

        protected override IList<TweenCommand> GetTweenCommands(EffectSpriteInstance obj)
        {
            var def = _defaultCommands.Copy();
            var off = def[2].Clone();
            def[2] = off;

            off.Properties[1] = CDGMath.RandomInt(-50, 50).ToString();
            off.Properties[3] = CDGMath.RandomInt(-50, 50).ToString();
            off.Properties[5] = CDGMath.RandomInt(-180, 180).ToString();

            return def;
        }

        public static void Display(Vector2 position)
        {
            for (int i = 0; i < 4; i++)
                Instance.Run(new Vector2(position.X + CDGMath.RandomInt(-20, 20), position.Y + CDGMath.RandomInt(-20, 20)));
        }
    }
}
