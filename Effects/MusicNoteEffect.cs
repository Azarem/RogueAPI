using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class MusicNoteEffect : EffectDefinition
    {
        public static readonly MusicNoteEffect Instance = new MusicNoteEffect();

        protected static readonly TweenCommand[] _defaultTweens = new[] {
            new TweenCommand(true, 1f, Quad.EaseOut, "Y", "-50"),
            new TweenCommand(false, 0.5f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0.8", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultTweens; } }

        protected MusicNoteEffect()
        {
            _spriteName = "NoteWhite_Sprite";
            _scale = new Vector2(2f);
            _opacity = 0;
            _animateFlag = true;
        }

        protected override EffectSpriteInstance CreateSprite(Vector2 position)
        {
            var sprite = base.CreateSprite(position);

            if (CDGMath.RandomPlusMinus() < 0)
                sprite.Flip = SpriteEffects.FlipHorizontally;

            return sprite;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
