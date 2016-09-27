using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class CrowFeatherEffect : EffectDefinition
    {
        public static readonly CrowFeatherEffect Instance = new CrowFeatherEffect();

        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.1f, Tween.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 1.5f, Quad.EaseInOut, "X", "0", "Y", "0", "Rotation", "0"),
            new TweenCommand(false, 1f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override float Rotation { get { return CDGMath.RandomInt(-30, 30); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected CrowFeatherEffect()
        {
            _spriteName = "CrowFeather_Sprite";
            _scale = new Vector2(2f);
            _opacity = 0f;
            _animateFlag = true;
        }

        public static void Display(Vector2 position)
        {
            lock (_defaultCommands)
                for (int i = 0; i < 4; i++)
                    Instance.Run(new Vector2(position.X + CDGMath.RandomInt(-20, 20), position.Y + CDGMath.RandomInt(-20, 20)), x =>
                    {
                        var cmd = _defaultCommands[1];
                        cmd.Properties[1] = CDGMath.RandomInt(-50, 50).ToString();
                        cmd.Properties[3] = CDGMath.RandomInt(-50, 50).ToString();
                        cmd.Properties[5] = CDGMath.RandomInt(-180, 180).ToString();
                    });
        }
    }
}
