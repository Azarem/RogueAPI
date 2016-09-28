using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class CarnivalGoldEffect : EffectDefinition
    {
        public static readonly CarnivalGoldEffect Instance = new CarnivalGoldEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(true, 0.3f, Quad.EaseInOut, "X", "0", "Y", "0"),
            new TweenCommand(false, 0.5f, Quad.EaseIn, "delay", "0", "X", "0", "Y", "0") { InitialValues = new float[2], EndHandler = new TweenEndHandler("StopAnimation") }
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected CarnivalGoldEffect()
        {
            _spriteName = "Coin_Sprite";
            _animateFlag = true;
        }

        public static void Display(Vector2 start, Vector2 end, int numCoins)
        {
            float delay = 0.32f;
            lock (_defaultCommands)
                for (int i = 0; i < numCoins; i++, delay += 0.05f)
                    Instance.Run(start, x =>
                    {
                        int xDrift = CDGMath.RandomInt(-30, 30);
                        int yDrift = CDGMath.RandomInt(-30, 30);

                        var cmd = _defaultCommands[0];
                        cmd.Properties[1] = xDrift.ToString();
                        cmd.Properties[3] = yDrift.ToString();

                        cmd = _defaultCommands[1];
                        cmd.Properties[1] = delay.ToString();
                        cmd.Properties[3] = end.X.ToString();
                        cmd.Properties[5] = end.Y.ToString();

                        cmd.InitialValues[0] = start.X + xDrift;
                        cmd.InitialValues[1] = start.Y + yDrift;
                    });
        }
    }
}
