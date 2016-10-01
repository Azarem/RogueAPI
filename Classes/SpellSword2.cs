using System;
using System.Linq;
using RogueAPI.Game;
using RogueAPI.Stats;
using RogueAPI.Effects;
using Microsoft.Xna.Framework;

namespace RogueAPI.Classes
{
    public class SpellSword2 : SpellSword
    {
        new public const byte Id = 14;
        new public static readonly SpellSword2 Instance = new SpellSword2();

        private SpellSword2()
            : this(Id)
        {
            this.DisplayName = "Spellsword";
            this.Description = "A hero for experts. Hit enemies to restore mana.\nSPECIAL: Empowered Spell.";
            this.ProfileCardDescription = "SPECIAL: Empowered Spell.\n30% of damage dealt is converted into mana.\nLow Str, HP, and MP.";
        }

        protected SpellSword2(byte id)
            : base(id)
        {
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            player.GetStatObject(ManaCostStat.Id).AddHandler(CalculateManaCost);
            Event<SpellCastEvent>.Handler += SpellCast;
            Event<EffectDisplayEvent>.Handler += EffectDisplay;
        }

        private void SpellCast(SpellCastEvent obj)
        {
            if (obj.Projectile != null)
            {
                obj.Projectile.Scale *= 1.75f;
                obj.Projectile.Damage *= 2;
            }
        }

        protected internal override void Deactivate(Player player)
        {
            player.GetStatObject(ManaCostStat.Id).RemoveHandler(CalculateManaCost);
            base.Deactivate(player);
        }

        protected virtual void CalculateManaCost(StatCalculation calc)
        {
            calc.Multiplier *= 2;
        }

        protected virtual void EffectDisplay(EffectDisplayEvent args)
        {
            //if (args.Effect is SpellCastEffect)
            //    args.Sprite.TextureColor = Color.Red;
        }
    }
}
