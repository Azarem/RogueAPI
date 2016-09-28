using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class DustEffect : EffectDefinition
    {
        public static readonly DustEffect Instance = new DustEffect();

        protected static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.2f, Linear.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 0.7f, Linear.EaseNone, "Rotation", "180"),
            new TweenCommand(true, 0.7f, Quad.EaseOut, "X", "0", "Y", "0"),
            new TweenCommand(false, 0.5f, Linear.EaseNone, "delay", "0.2", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") },
        };


        public override float Rotation { get { return CDGMath.RandomInt(0, 270); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected DustEffect()
        {
            _spriteName = "ExplosionBrown_Sprite";
            _opacity = 0;
            _scale = new Vector2(0.8f);
            _animateFlag = true;
        }

        public static void DisplayFart(GameObj source)
        {
            Display(source, true);
        }

        public static void Display(GameObj source, bool useFlip = false)
        {
            Display(new Vector2(source.X, source.Bounds.Bottom), useFlip ? source.Flip == SpriteEffects.FlipHorizontally : (bool?)null);
        }
        public static void Display(Vector2 position)
        {
            Display(position, null);
        }

        public static void DisplayTurretFire(Vector2 position, float scale)
        {
            Display(position, null, 20, 50, scale);
        }

        public static void Display(Vector2 position, bool? flip = null, int drift = 30, int? rotateRange = null, float scale = 0.8f)
        {
            lock (_defaultCommands)
                Instance.Run(position, x =>
                {
                    x.Sprite.Scale = new Vector2(scale);

                    float xDrift, yDrift;

                    if (flip != null)
                    {
                        if (flip.Value)
                        {
                            x.Sprite.X += 30f;
                            xDrift = 20f;
                        }
                        else
                        {
                            x.Sprite.X -= 30f;
                            xDrift = -20f;
                        }

                        yDrift = 0f;
                    }
                    else
                    {
                        xDrift = CDGMath.RandomInt(-drift, drift);
                        yDrift = CDGMath.RandomInt(-drift, drift);
                    }

                    var cmd = x.TweenCommands[0];
                    cmd.Properties[1] = "1";

                    cmd = x.TweenCommands[1];
                    cmd.Properties[1] = rotateRange == null ? "180" : CDGMath.RandomInt(-rotateRange.Value, rotateRange.Value).ToString();

                    cmd = x.TweenCommands[2];
                    cmd.Properties[1] = xDrift.ToString();
                    cmd.Properties[3] = yDrift.ToString();

                    cmd = x.TweenCommands[3];
                    cmd.Duration = rotateRange == null ? 0.5f : 0.4f;
                    cmd.InitialValues[0] = 1f;
                });
        }

    }
}
