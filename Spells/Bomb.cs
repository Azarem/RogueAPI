using Microsoft.Xna.Framework;
using RogueAPI.Game;
using RogueAPI.Projectiles;

namespace RogueAPI.Spells
{
    public class Bomb : SpellDefinition
    {
        public const byte Id = 3;
        public static readonly Bomb Instance = new Bomb();

        private Bomb() : this(Id) { }

        protected Bomb(byte id)
            : base(id)
        {
            displayName = "Bomb";
            icon = "TimeBombIcon_Sprite";
            description = string.Format("[Input:{0}]  Summons a bomb that explodes after a while.", (int)Game.InputKeys.PlayerSpell1);
  
            rarity = 1;
            manaCost = 15;
            damageMultiplier = 1.5f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = BombProjectile.Fire(source.GameObject);

            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);

            return true;
        }
    }
}
