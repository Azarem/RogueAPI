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
    public class FlameBarrier : SpellDefinition
    {
        public const byte Id = 11;
        public static readonly FlameBarrier Instance = new FlameBarrier();

        private FlameBarrier() : this(Id) { }

        protected FlameBarrier(byte id)
            : base(id)
        {
            displayName = "Flame Barrier";
            icon = "DamageShieldIcon_Sprite";
            description = string.Format("[Input:{0}]  Encircles you with protective fire.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_FireShield" };

            rarity = 2;
            manaCost = 15;
            damageMultiplier = 1.0f;

            toggle = true;
            manaDrainAmount = 6f;
            manaDrainTime = 0.33f;
        }

        protected override bool OnCast(Entity source)
        {
            var numProjectiles = 5;
            for (int j = 0; j < numProjectiles; j++)
            {
                var proj = FlameBarrierProjectile.Fire(source.GameObject, j, numProjectiles, 200);
                Effects.SpellCastEffect.Display(proj.Position, proj.Rotation);
            }

            return true;
        }

        protected override void OnDeactivate()
        {
            base.Deactivate();

            foreach (var p in Core.GetActiveProjectiles().Where(x => x.Definition is FlameBarrierProjectile && x.Source.IsPlayer()))
                p.KillProjectile();
        }
    }
}
