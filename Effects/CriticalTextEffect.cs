using System.Collections.Generic;
using Microsoft.Xna.Framework;
using DS2DEngine;
using Tweener.Ease;
using Tweener;

namespace RogueAPI.Effects
{
    public class CriticalTextEffect : EffectDefinition
    {
        public static readonly CriticalTextEffect Instance = new CriticalTextEffect();

        private static readonly IList<TweenCommand> _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.2f, Back.EaseOutLarge, "ScaleX", "1", "ScaleY", "1"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override float Rotation { get { return CDGMath.RandomInt(-20, 20); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected CriticalTextEffect()
        {
            _spriteName = "CriticalText_Sprite";
            _scale = Vector2.Zero;
            _animateFlag = true;
        }

        protected override EffectSpriteInstance CreateSprite(Vector2 position)
        {
            var sprite = base.CreateSprite(position);

            sprite.Position = CDGMath.GetCirclePosition(sprite.Rotation - 90f, 20f, sprite.Position);

            return sprite;
        }

        public static void Display(GameObj source)
        {
            Display(new Vector2(source.X, source.Bounds.Top));
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
