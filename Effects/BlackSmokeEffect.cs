using DS2DEngine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class BlackSmokeEffect : EffectDefinition
    {
        public static readonly BlackSmokeEffect Instance = new BlackSmokeEffect();
        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.4f, Tween.EaseNone, "delay", "0", "Opacity", "1"),
            new TweenCommand(true, 1.5f, Quad.EaseInOut, "delay", "0", "X", "0", "Y", "0", "Rotation", "0"),
            new TweenCommand(false, 1f, Tween.EaseNone, "delay", "0.5", "Opacity", "0") { InitialValues = new [] { 0, 1f }, EndHandler = new TweenEndHandler("StopAnimation") }
        };

        public override float Rotation { get { return CDGMath.RandomInt(-30, 30); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected BlackSmokeEffect()
        {
            _spriteName = "BlackSmoke_Sprite";
            _opacity = 0;
            _animateFlag = true;
        }


        public static void Display(Vector2 position, int xRange = 40, int yRange = 40, float scale = 1f, bool? flip = null, bool furtherDrift = false, bool longerDuration = false, bool randomDelay = false)
        {
            lock (_defaultCommands)
            {
                var pos = position;
                if (xRange != 0)
                    pos.X += CDGMath.RandomInt(-xRange, xRange);
                if (yRange != 0)
                    pos.Y += CDGMath.RandomInt(-yRange, yRange);

                Instance.Run(pos, x =>
                {
                    x.Sprite.Scale = new Vector2(scale);

                    int xDrift, yDrift;

                    if (furtherDrift)
                    {
                        xDrift = CDGMath.RandomInt(50, 100);
                        yDrift = CDGMath.RandomInt(-100, 100);
                    }
                    else
                    {
                        xDrift = CDGMath.RandomInt(-50, 50);
                        yDrift = CDGMath.RandomInt(-50, 50);
                    }

                    if (flip != null)
                    {
                        if (CDGMath.RandomPlusMinus() < 0)
                            x.Sprite.Flip = SpriteEffects.FlipHorizontally;

                        if (CDGMath.RandomPlusMinus() < 0)
                            x.Sprite.Flip = SpriteEffects.FlipVertically;

                        xDrift = -xDrift;
                    }

                    TweenCommand cmd0 = x.TweenCommands[0], cmd1 = x.TweenCommands[1], cmd2 = x.TweenCommands[2];

                    cmd1.Properties[3] = xDrift.ToString();
                    cmd1.Properties[5] = yDrift.ToString();

                    if (longerDuration)
                    {
                        cmd0.Duration = 0.4f;
                        cmd1.Duration = 1.5f;
                        cmd2.Duration = 1f;
                    }
                    else
                    {
                        cmd0.Duration = 0.2f;
                        cmd1.Duration = 1f;
                        cmd2.Duration = 0.5f;
                    }

                    float delay = randomDelay ? CDGMath.RandomFloat(0f, 0.2f) : 0f;

                    cmd0.Properties[1] = delay.ToString();
                    cmd1.Properties[1] = delay.ToString();
                    cmd2.Properties[1] = (delay + 0.5f).ToString();

                    cmd1.Properties[7] = CDGMath.RandomInt(-45, 45).ToString();
                });

            }
        }

        public static void DisplayIntroSmoke(Vector2 pos)
        {
            Display(pos, scale: 2.5f, randomDelay: true);
        }

        public static void DisplayCrowDestruction(Vector2 position, int number = 2)
        {
            for (int i = 0; i < number; i++)
                Display(position, xRange: 0, yRange: 0, longerDuration: true, furtherDrift: true, randomDelay: true);
        }

        public static void DisplayCrowSmoke(Vector2 position)
        {
            Display(position, scale: 0.7f, furtherDrift: true);
        }

        public static void Display(GameObj source, int number = 2)
        {
            bool invertX = source.Flip != SpriteEffects.FlipHorizontally;
            float posX = invertX ? source.Bounds.Left : source.Bounds.Right;

            for (int i = 0; i < number; i++)
                Display(new Vector2(posX, source.Y), xRange: 0, flip: invertX, longerDuration: true, furtherDrift: true);
        }

    }
}
