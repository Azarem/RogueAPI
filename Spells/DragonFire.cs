using Microsoft.Xna.Framework;
using RogueAPI.Game;

namespace RogueAPI.Spells
{
    public class DragonFire : SpellDefinition
    {
        public const byte Id = 13;
        public static readonly DragonFire Instance = new DragonFire();

        private DragonFire() : this(Id) { }

        protected DragonFire(byte id)
            : base(id)
        {
            displayName = "Dragon Fire";
            icon = "DragonFireIcon_Sprite";
            description = string.Format("[Input:{0}]  Shoot fireballs at your enemies.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Enemy_WallTurret_Fire_01", "Enemy_WallTurret_Fire_02", "Enemy_WallTurret_Fire_03", "Enemy_WallTurret_Fire_04" };

            rarity = 3;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = Projectiles.DragonFireProjectile.Fire(source.GameObject);
            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);
            return true;
        }
    }
}
