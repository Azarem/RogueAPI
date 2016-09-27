using Microsoft.Xna.Framework;
using RogueAPI.Game;

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
            manaCost = 0;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = Projectiles.DragonFireNeoProjectile.Fire(source.GameObject);
            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);
            return true;
        }
    }
}
