using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DS2DEngine;
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

        public override Vector2 Scale { get { return new Vector2(CDGMath.RandomFloat(0.2f, 0.5f)); } }
        public override float Rotation { get { return CDGMath.RandomInt(0, 90); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        private ChestSparkleEffect()
        {
            _spriteName = "LevelUpParticleFX_Sprite";
            _opacity = 0f;
            _animateFlag = false;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position + new Vector2(CDGMath.RandomInt(-40, 40), CDGMath.RandomInt(-40, 40)));
        }
    }
}
