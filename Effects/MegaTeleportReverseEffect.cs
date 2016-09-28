using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class MegaTeleportReverseEffect : EffectDefinition
    {
        public static readonly MegaTeleportReverseEffect Instance = new MegaTeleportReverseEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(true, 0.1f, Tween.EaseNone, "Y", "720") { EndHandler = new TweenEndHandler("PlayAnimation", false) }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected MegaTeleportReverseEffect()
        {
            _spriteName = "MegaTeleportReverse_Sprite";
            _animationDelay = 1f / 60;
            _animateFlag = true;
        }

        protected override void Animate(EffectSpriteInstance sprite)
        {
            sprite.PlayAnimation(1, 1, true);
        }

        public static void Display(Vector2 position, Vector2 scale)
        {
            Instance.Run(position, x =>
            {
                x.Sprite.TextureColor = Color.LightSkyBlue;
                x.Sprite.Scale = scale;
                x.Sprite.Y -= 720f;
            });
        }
    }
}
