using Microsoft.Xna.Framework;
using RogueAPI.Game;
using RogueAPI.Projectiles;

namespace RogueAPI.Spells
{
    public class Chakram : SpellDefinition
    {
        public const byte Id = 8;
        public static readonly Chakram Instance = new Chakram();

        private Chakram() : this(Id) { }

        protected Chakram(byte id)
            : base(id)
        {
            displayName = "Chakram";
            icon = "BoomerangIcon_Sprite";
            description = string.Format("[Input:{0}]  Throws a chakram which comes back to you.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_Boomerang" };

            rarity = 2;
            manaCost = 10;
            damageMultiplier = 1f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = ChakramProjectile.Fire(source.GameObject);

            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation);

            return true;
        }
    }
}
