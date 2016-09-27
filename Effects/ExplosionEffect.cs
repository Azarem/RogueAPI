using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class ExplosionEffect : EffectDefinition
    {
        public static readonly ExplosionEffect Instance = new ExplosionEffect();

        protected ExplosionEffect()
        {
            _spriteName = "EnemyDeathFX1_Sprite";
            _scale = new Vector2(2f);
            _animationDelay = 1f / 30;
            _animateFlag = false;
        }

        public static void Display(Vector2 position)
        {
            Instance.Run(position);
        }
    }
}
