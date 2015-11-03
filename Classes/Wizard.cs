using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Spells;
using RogueAPI.Game;

namespace RogueAPI.Classes
{
    public class Wizard : ClassDefinition
    {
        public const byte Id = 1;
        public static readonly Wizard Instance = new Wizard();

        private Wizard() : this(Id) { }

        protected Wizard(byte id)
            : base(id)
        {
            this.DisplayName = "Mage";
            this.Description = "A powerful spellcaster. Every kill gives you mana.";
            this.ProfileCardDescription = "Every kill gives you 6 mana.\nLow Str and HP.  High Int and MP.";
            this.PhysicalDamageMultiplier = 0.5f;
            this.HealthMultiplier = 0.5f;
            this.ManaMultiplier = 1.5f;
            this.MagicDamageMultiplier = 1.25f;
            this.ManaGainBonus = 6;

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(4));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
            this.AssignedSpells.Add(SpellDefinition.GetById(11));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }

        private float sparkleCounter;

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Game.Player.PlayerEffectsUpdating += Player_PlayerEffectsUpdating;
            sparkleCounter = 0.2f;
        }

        protected internal override void Deactivate(Player player)
        {
            Game.Player.PlayerEffectsUpdating -= Player_PlayerEffectsUpdating;
            base.Deactivate(player);
        }

        void Player_PlayerEffectsUpdating(ObjContainer player, GameTime gameTime)
        {
            sparkleCounter -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (sparkleCounter <= 0f)
            {
                sparkleCounter = 0.2f;
                Core.AttachEffect(EffectType.ChestSparkle, player, null);
                Core.AttachEffect(EffectType.ChestSparkle, player, null);
            }
        }
    }
}
