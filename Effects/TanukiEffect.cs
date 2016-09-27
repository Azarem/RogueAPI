using Microsoft.Xna.Framework;
using DS2DEngine;

namespace RogueAPI.Effects
{
    public class TanukiEffect : DeathEffect
    {
        new public static readonly TanukiEffect Instance = new TanukiEffect();

        protected TanukiEffect()
        {
            _spriteName = "ExplosionBrown_Sprite";
        }

        new public static void Display(Vector2 position, int numEffects = 10)
        {
            lock (_defaultTweens)
                for (int i = 0; i < numEffects; i++)
                    Instance.Run(new Vector2(position.X + CDGMath.RandomInt(-30, 30), position.Y + CDGMath.RandomInt(-30, 30)), Initialize);
        }

    }
}
