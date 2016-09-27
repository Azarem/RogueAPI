using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueAPI.Game;
using RogueAPI.Projectiles;

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

            rarity = 1;
            manaCost = 15;
            damageMultiplier = 1.0f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = ScytheProjectile.Fire(source.GameObject);
            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);

            proj = ScytheProjectile.Fire(source.GameObject, true);
            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);

            return true;
        }
    }
}
