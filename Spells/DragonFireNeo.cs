using Microsoft.Xna.Framework;

namespace RogueAPI.Spells
{
    public class DragonFireNeo : DragonFire
    {
        new public const byte Id = 15;
        new public static readonly DragonFireNeo Instance = new DragonFireNeo();

        private DragonFireNeo() : this(Id) { }

        protected DragonFireNeo(byte id)
            : base(id)
        {
            baseProjectile.Speed = new Vector2(1750f, 1750f);
            baseProjectile.Lifespan = 0.75f;
            baseProjectile.Scale = new Vector2(2.75f, 2.75f);
            baseProjectile.WrapProjectile = true;
            miscValue1 = 0.75f;
            manaCost = 0;
        }
    }
}
