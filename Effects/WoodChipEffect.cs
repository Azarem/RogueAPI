using DS2DEngine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Tweener;

namespace RogueAPI.Effects
{
    public class WoodChipEffect : EffectDefinition
    {
        public static readonly WoodChipEffect Instance = new WoodChipEffect();

        protected static readonly TweenCommand[] _defaultCommands = new[] {
            new TweenCommand(true, 0.3f, Tween.EaseNone, "X", "0", "Y", "0", "Rotation", "0"),
            new TweenCommand(false, 0.2f, Tween.EaseNone, "delay", "0.1", "Opacity", "0")
        };

        protected override IList<TweenCommand> TweenCommands { get { return _defaultCommands; } }
        public override float Rotation { get { return CDGMath.RandomInt(-360, 360); } }

        protected WoodChipEffect()
        {
            _spriteName = "WoodChip_Sprite";
            _scale = new Vector2(2f);
            _animateFlag = true;
        }

        public static void Display(Vector2 position, int numEffects = 5)
        {
            lock (_defaultCommands)
                for (int i = 0; i < numEffects; i++)
                    Instance.Run(position, x =>
                    {
                        var cmd = _defaultCommands[0];
                        cmd.Properties[1] = CDGMath.RandomInt(-60, 60).ToString();
                        cmd.Properties[3] = CDGMath.RandomInt(-60, 60).ToString();
                        cmd.Properties[5] = CDGMath.RandomInt(-360, 360).ToString();
                    });
        }
    }
}
