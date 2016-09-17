using Microsoft.Xna.Framework;
using RogueAPI.Game;

namespace RogueAPI.Spells
{
    public class BladeWall : SpellDefinition
    {
        public const byte Id = 10;
        public static readonly BladeWall Instance = new BladeWall();

        private BladeWall() : this(Id) { }

        protected BladeWall(byte id)
            : base(id)
        {
            displayName = "Blade Wall";
            icon = "CloseIcon_Sprite";
            description = string.Format("[Input:{0}]  Summon a Grand Blade to defend you.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_GiantSword" };

            rarity = 2;
            manaCost = 15;
            damageMultiplier = 0.5f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = Projectiles.GiantSwordProjectile.Fire(source.GameObject);

            Effects.SpellCastEffect.Display(proj.Position, 90f);

            return true;
        }
    }
}
