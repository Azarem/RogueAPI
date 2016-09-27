using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueAPI.Game;

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

            rarity = 3;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }

        protected override bool OnCast(Entity source)
        {
            Projectiles.LaserProjectile.Fire(source.GameObject);
            return true;
        }
    }
}
