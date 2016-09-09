using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class FusRoDahTextEffect : EffectDefinition
    {
        public static readonly FusRoDahTextEffect Instance = new FusRoDahTextEffect();
        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.2f, Back.EaseOutLarge, "ScaleX", "1", "ScaleY", "1"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override float Rotation
        {
            get { return CDGMath.RandomInt(-20, 20); }
            set { }
        }

        protected FusRoDahTextEffect()
        {
            SpriteName = "FusRoDahText_Sprite";
            Scale = Vector2.Zero;
            AnimationFlag = true;
        }

        protected override SpriteObj CreateSprite(Vector2 position)
        {
            var sprite = base.CreateSprite(position);
            CDGMath.GetCirclePosition(sprite.Rotation - 90f, 40f, position);
            return sprite;
        }
        protected override IEnumerable<TweenCommand> GetTweenCommands(SpriteObj obj)
        {
            return _defaultCommands;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
