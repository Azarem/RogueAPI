using Microsoft.Xna.Framework;

namespace RogueAPI.Spells
{
    public class RapidDagger : SpellDefinition
    {
        public const byte Id = 14;
        public static readonly RapidDagger Instance = new RapidDagger();

        private RapidDagger() : this(Id) { }

        protected RapidDagger(byte id)
            : base(id)
        {
            displayName = "Rapid Dagger";
            icon = "RapidDaggerIcon_Sprite";
            description = string.Format("[Input:{0}]  Fire a barrage of daggers.", (int)Game.InputKeys.PlayerSpell1);
            baseProjectile.SpriteName = "LaserSpell_Sprite";
            baseProjectile.Angle = new Vector2(0f, 0f);
            baseProjectile.Speed = new Vector2(0f, 0f);
            baseProjectile.IsWeighted = false;
            baseProjectile.IsCollidable = false;
            baseProjectile.StartingRotation = 0f;
            baseProjectile.FollowArc = false;
            baseProjectile.RotationSpeed = 0f;
            baseProjectile.DestroysWithTerrain = false;
            baseProjectile.DestroysWithEnemy = false;
            baseProjectile.CollidesWithTerrain = false;
            baseProjectile.LockPosition = true;
            miscValue1 = 0f;
            miscValue2 = 0f;
            rarity = 1;
            manaCost = 30;
            damageMultiplier = 0.75f;
        }
    }
}
