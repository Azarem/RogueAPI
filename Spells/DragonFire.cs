using Microsoft.Xna.Framework;

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
            baseProjectile.SpriteName = "TurretProjectile_Sprite";
            baseProjectile.Angle = Vector2.Zero;
            baseProjectile.SourceAnchor = new Vector2(50f, 0f);
            baseProjectile.Speed = new Vector2(1100f, 1100f);
            baseProjectile.Lifespan = 0.35f;
            baseProjectile.IsWeighted = false;
            baseProjectile.RotationSpeed = 0f;
            baseProjectile.CollidesWithTerrain = true;
            baseProjectile.DestroysWithTerrain = true;
            baseProjectile.Scale = new Vector2(2.5f, 2.5f);
            miscValue1 = 0.35f;
            miscValue2 = 0f;
            rarity = 3;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }
    }
}
