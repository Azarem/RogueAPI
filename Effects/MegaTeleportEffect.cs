using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class MegaTeleportEffect : EffectDefinition
    {
        public static readonly MegaTeleportEffect Instance = new MegaTeleportEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(true, 0.1f, Tween.EaseNone, "delay", "0.15", "Y", "-720")
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected MegaTeleportEffect()
        {
            _spriteName = "MegaTeleport_Sprite";
            _animationDelay = 1f / 60;
            _animateFlag = false;
        }

        public static void Display(Vector2 position, Vector2 scale)
        {
            Instance.Run(position, x =>
            {
                x.Sprite.TextureColor = Color.LightSkyBlue;
                x.Sprite.Scale = scale;
            });
        }
    }
}
