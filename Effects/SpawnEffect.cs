using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class SpawnEffect : DeathEffect
    {
        new public static readonly SpawnEffect Instance = new SpawnEffect();

        protected SpawnEffect()
        {
            _spriteName = "ExplosionOrange_Sprite";
        }

        new public static void Display(Vector2 position, int number = 10)
        {
            lock (_defaultTweens)
                for (int i = 0; i < number; i++)
                    Instance.Run(position, Initialize);
        }
    }
}
