using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using DS2DEngine;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    //Shown on player update, when not in ending room and scale > 0.1, and SpellSword class
    public class ChestSparkleEffect : EffectDefinition
    {
        public static readonly ChestSparkleEffect Instance = new ChestSparkleEffect();

        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.2f, Linear.EaseNone, "Opacity", "1") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override Vector2 Scale
        {
            get { return new Vector2(CDGMath.RandomFloat(0.2f, 0.5f)); }
            set { }
        }

        public override float Rotation
        {
            get { return CDGMath.RandomInt(0, 90); }
            set { }
        }

        private ChestSparkleEffect()
        {
            SpriteName = "LevelUpParticleFX_Sprite";
            Opacity = 0f;
            AnimationFlag = false;
        }

        protected override IList<TweenCommand> GetTweenCommands(EffectSpriteInstance obj)
        {
            return _defaultCommands;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position + new Vector2(CDGMath.RandomInt(-40, 40), CDGMath.RandomInt(-40, 40)));
        }
    }
}
