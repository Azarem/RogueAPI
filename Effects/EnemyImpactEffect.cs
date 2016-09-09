using DS2DEngine;
using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class EnemyImpactEffect : EffectDefinition
    {
        public static readonly EnemyImpactEffect Instance = new EnemyImpactEffect();

        public override float Rotation
        {
            get { return CDGMath.RandomInt(0, 360); }
            set { }
        }

        protected EnemyImpactEffect()
        {
            SpriteName = "ImpactEnemy_Sprite";
            AnimationFlag = false;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
