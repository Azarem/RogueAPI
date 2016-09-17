using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Spells
{
    public class Scythe : SpellDefinition
    {
        public const byte Id = 9;
        public static readonly Scythe Instance = new Scythe();

        private Scythe() : this(Id) { }

        protected Scythe(byte id)
            : base(id)
        {
            displayName = "Scythe";
            icon = "DualBladesIcon_Sprite";
            description = string.Format("[Input:{0}]  Send Scythes flying out from above you.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_Chakram" };
            baseProjectile.SpriteName = "SpellDualBlades_Sprite";
            baseProjectile.Angle = new Vector2(-55f, -55f);
            baseProjectile.SourceAnchor = new Vector2(50f, 30f);
            baseProjectile.Speed = new Vector2(1000f, 1000f);
            baseProjectile.IsWeighted = false;
            baseProjectile.RotationSpeed = 30f;
            baseProjectile.CollidesWithTerrain = false;
            baseProjectile.DestroysWithTerrain = false;
            baseProjectile.DestroysWithEnemy = false;
            baseProjectile.Scale = new Vector2(2f, 2f);
            miscValue1 = 0f;
            miscValue2 = 0f;
            rarity = 1;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }
    }
}
