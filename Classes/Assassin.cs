using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Spells;
using RogueAPI.Game;

namespace RogueAPI.Classes
{
    public class Assassin : ClassDefinition
    {
        public const byte Id = 3;
        public static readonly Assassin Instance = new Assassin();

        private Assassin()
            : this(Id)
        {
            this.DisplayName = "Knave";
            this.Description = "A risky hero. Low stats but can land devastating critical strikes.";
            this.ProfileCardDescription = "+15% Crit. Chance, +125% Crit. Damage.\nLow HP, MP, and Str.";
        }

        protected Assassin(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 0.75f;
            this.ManaMultiplier = 0.65f;
            this.CriticalChanceBonus = 0.15f;
            this.CriticalDamageBonus = 1.25f;

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(6));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }

        private float smokeTimer;

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Game.Player.RetrievingSkinColor += Player_RetrievingSkinColor;
            Game.Player.PlayerEffectsUpdating += Player_PlayerEffectsUpdating;
            smokeTimer = 0.5f;
        }


        protected internal override void Deactivate(Player player)
        {
            Game.Player.PlayerEffectsUpdating -= Player_PlayerEffectsUpdating;
            Game.Player.RetrievingSkinColor -= Player_RetrievingSkinColor;
            base.Deactivate(player);
        }

        void Player_RetrievingSkinColor(PipeEventState<DS2DEngine.Screen, Game.Player.SkinShaderArgs> args)
        {
            if (!args.Handled)
            {
                args.Target.Opacity = args.Target.PlayerSprite.Opacity;
                args.Target.ColorSwappedIn1 = Color.Black;
                args.Target.ColorSwappedIn2 = Color.Black;
                args.Handled = true;
            }
        }


        void Player_PlayerEffectsUpdating(ObjContainer obj, GameTime gameTime)
        {
            smokeTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (smokeTimer <= 0f)
            {
                smokeTimer = obj.CurrentSpeed > 0f ? 0.05f : 0.15f;
                Core.AttachEffect(EffectType.BlackSmoke, obj, null);
            }
        }


        //ProfileCardScreen.Draw - Alter skin color to use Black
        //PlayerObj.Update - Create smoke effect
        //PlayerObj.Draw - Alter skin color to use Black
        //CreditsScreen.Draw - Alter skin color to use Black


    }
}
