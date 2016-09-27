using Microsoft.Xna.Framework;
using RogueAPI.Game;
using RogueAPI.Projectiles;

namespace RogueAPI.Spells
{
    public class Dagger : SpellDefinition
    {
        public const byte Id = 1;
        public static readonly Dagger Instance = new Dagger();

        private Dagger() : this(Id) { }

        protected Dagger(byte id)
            : base(id)
        {
            displayName = "Dagger";
            icon = "DaggerIcon_Sprite";
            description = string.Format("[Input:{0}]  Fires a dagger directly in front of you.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_Dagger" };

            rarity = 1;
            manaCost = 10;
            damageMultiplier = 1.0f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = DaggerProjectile.Fire(source.GameObject);
            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);
            return true;
        }
    }
}
