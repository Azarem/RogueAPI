using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class TranslocateEffect : EffectDefinition
    {
        public static readonly TranslocateEffect Instance = new TranslocateEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(true, 1f, Quad.EaseIn, "X", "0", "Y", "0"),
            new TweenCommand(false, 0.5f, Linear.EaseNone, "delay", "0.5", "ScaleX", "0", "ScaleY", "0") { EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected TranslocateEffect()
        {
            _spriteName = "Blank_Sprite";
            _scale = new Vector2(2f);
            _animateFlag = true;
        }

        public static void Display(Vector2 position, int numEffects = 30)
        {
            lock (_defaultCommands)
                for (int i = 0; i < numEffects; i++)
                    Instance.Run(position, x =>
                    {
                        var cmd = _defaultCommands[0];
                        cmd.Properties[1] = CDGMath.RandomInt(-250, 250).ToString();
                        cmd.Properties[3] = CDGMath.RandomInt(500, 800).ToString();
                    });
        }
    }
}
