using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener.Ease;

namespace RogueAPI.Effects
{
    public class SkillTreeDustEffect : EffectDefinition
    {
        public static readonly SkillTreeDustEffect Instance = new SkillTreeDustEffect();

        private static readonly TweenCommand[] _defaultCommands = new TweenCommand[] {
            new TweenCommand(false, 0.5f, Linear.EaseNone, "Opacity", "1"),
            new TweenCommand(true, 1.5f, Linear.EaseNone, "Rotation", "0"),
            new TweenCommand(true, 1.5f, Quad.EaseOut, "X", "0", "Y", "0"),
            new TweenCommand(false, 1.5f, Quad.EaseOut, "ScaleX", "0", "ScaleY", "0"),
            new TweenCommand(false, 0.7f, Linear.EaseNone, "delay", "0.6", "Opacity", "0") { InitialValues = new [] { 1f }, EndHandler = new TweenEndHandler("StopAnimation") },
        };

        public override float Rotation { get { return CDGMath.RandomInt(0, 270); } }
        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }

        protected SkillTreeDustEffect()
        {
            _spriteName = "ExplosionBrown_Sprite";
            _opacity = 0f;
            _scale = new Vector2(0.5f);
            _animateFlag = true;
        }

        public static void Display(Vector2 position, bool horizontal, float length)
        {
            int numEffects = (int)(length / 20);
            float posScale = length / numEffects;
            Vector2 posFactor = (horizontal ? new Vector2(1f, 0f) : new Vector2(0f, -1f)) * posScale;

            lock (_defaultCommands)
                for (int i = 0; i < numEffects; i++)
                    Instance.Run(position * (i + 1), x =>
                    {
                        float randScale = CDGMath.RandomFloat(0.5f, 0.8f);

                        var cmd = _defaultCommands[1];
                        cmd.Properties[1] = CDGMath.RandomFloat(-30f, 30f).ToString();

                        cmd = _defaultCommands[2];
                        cmd.Properties[1] = CDGMath.RandomInt(-10, 10).ToString();
                        cmd.Properties[3] = CDGMath.RandomInt(-20, 0).ToString();

                        cmd = _defaultCommands[3];
                        cmd.Properties[1] = randScale.ToString();
                        cmd.Properties[3] = randScale.ToString();
                    });
        }
    }
}
