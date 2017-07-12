using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Spells;
using RogueAPI.Game;

namespace RogueAPI.Classes
{
    public class Knave : ClassDefinition
    {
        public const byte Id = 3;
        public static readonly Knave Instance = new Knave();

        private Knave()
            : this(Id)
        {
            this.DisplayName = "Knave";
            this.Description = "A risky hero. Low stats but can land devastating critical strikes.";
            this.ProfileCardDescription = "+15% Crit. Chance, +125% Crit. Damage.\nLow HP, MP, and Str.";
        }

        protected Knave(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.HealthMultiplier = 0.75f;
            this.ManaMultiplier = 0.65f;
            this.CriticalChanceBonus = 0.15f;
            this.CriticalDamageBonus = 1.25f;

            this.AssignedSpells.Add(Axe.Instance);
            this.AssignedSpells.Add(Dagger.Instance);
            this.AssignedSpells.Add(Translocator.Instance);
            this.AssignedSpells.Add(Chakram.Instance);
            this.AssignedSpells.Add(Scythe.Instance);
            this.AssignedSpells.Add(Conflux.Instance);
        }

        private float smokeTimer;

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Game.Player.RetrievingSkinColor += Player_RetrievingSkinColor;
            Event<PlayerUpdateEvent>.Handler += PlayerUpdateHandler;
            smokeTimer = 0.5f;
        }


        protected internal override void Deactivate(Player player)
        {
            Event<PlayerUpdateEvent>.Handler -= PlayerUpdateHandler;
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


        protected virtual void PlayerUpdateHandler(PlayerUpdateEvent evt)
        {
            if (evt.UpdateEffects)
            {
                smokeTimer -= evt.ElapsedSeconds;

                if (smokeTimer <= 0f)
                {
                    smokeTimer = evt.Player.GameObject.CurrentSpeed > 0f ? 0.05f : 0.15f;
                    Effects.BlackSmokeEffect.Display(evt.Player.GameObject);
                }
            }
        }


        //ProfileCardScreen.Draw - Alter skin color to use Black
        //PlayerObj.Update - Create smoke effect
        //PlayerObj.Draw - Alter skin color to use Black
        //CreditsScreen.Draw - Alter skin color to use Black


    }
}
