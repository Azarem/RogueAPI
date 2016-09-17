using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Spells
{
    public class Laser : SpellDefinition
    {
        public const byte Id = 100;
        public static readonly Laser Instance = new Laser();

        private Laser() : this(Id) { }

        protected Laser(byte id)
            : base(id)
        {
            displayName = "B.E.A.M";
            icon = "DaggerIcon_Sprite";
            description = string.Format("[Input:{0}]  Fire a laser that blasts everyone it touches.", (int)Game.InputKeys.PlayerSpell1);
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
            miscValue1 = 5f;
            miscValue2 = 0f;
            rarity = 3;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }
    }
}
