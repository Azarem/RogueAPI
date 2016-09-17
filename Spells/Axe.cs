using Microsoft.Xna.Framework;
using RogueAPI.Game;
using RogueAPI.Projectiles;

namespace RogueAPI.Spells
{
    public class Axe : SpellDefinition
    {
        public const byte Id = 2;
        public static readonly Axe Instance = new Axe();

        private Axe() : this(Id) { }

        protected Axe(byte id)
            : base(id)
        {
            displayName = "Axe";
            icon = "AxeIcon_Sprite";
            description = string.Format("[Input:{0}]  Throws a giant axe in an arc.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_Axe" };
            
            rarity = 1;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = AxeProjectile.Fire(source.GameObject);

            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);

            return true;
        }
    }
}
