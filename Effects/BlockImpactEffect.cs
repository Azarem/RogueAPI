using DS2DEngine;
using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class BlockImpactEffect : EffectDefinition
    {
        public static readonly BlockImpactEffect Instance = new BlockImpactEffect();

        public override float Rotation { get { return CDGMath.RandomInt(0, 360); } }

        protected BlockImpactEffect()
        {
            _spriteName = "ImpactBlock_Sprite";
            _animateFlag = false;
        }

        public static void Display(Vector2 position, Vector2 scale)
        {
            Instance.Run(position, x =>
            {
                x.Sprite.Scale = scale;
            });
        }
    }
}
