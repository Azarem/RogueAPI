using System;
using System.Linq;
using Microsoft.Xna.Framework;
using RogueAPI.Spells;

namespace RogueAPI.Classes
{
    public class Lich : ClassDefinition
    {
        public const byte Id = 7;
        public static readonly Lich Instance = new Lich();

        public static Color SkinColor1 = new Color(255, 255, 255, 255);
        public static Color SkinColor2 = new Color(198, 198, 198, 255);

        private Lich()
            : this(Id)
        {
            this.DisplayName = "Lich";
            this.Description = "Feed off the dead. Gain permanent life for every kill up to a cap. Extremely intelligent.";
            this.ProfileCardDescription = "Kills are coverted into max HP.\nVery low Str, HP and MP.  High Int.";
        }

        protected Lich(byte id)
            : base(id)
        {
            this.PhysicalDamageMultiplier = 0.75f;
            this.MagicDamageMultiplier = 1.5f;
            this.HealthMultiplier = 0.35f;
            this.HealthMultiplier = 0.5f;

            this.AssignedSpells.Add(SpellDefinition.GetById(5));
            this.AssignedSpells.Add(SpellDefinition.GetById(11));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }

        protected internal override void Activate()
        {
            base.Activate();
            Game.Player.RetrievingSkinColor += Player_RetrievingSkinColor;
        }

        protected internal override void Deactivate()
        {
            Game.Player.RetrievingSkinColor -= Player_RetrievingSkinColor;
            base.Deactivate();
        }


        void Player_RetrievingSkinColor(PipeEventState<DS2DEngine.Screen, Game.Player.SkinShaderArgs> args)
        {
            if (!args.Handled)
            {
                args.Target.Opacity = args.Target.PlayerSprite.Opacity;
                args.Target.ColorSwappedIn1 = SkinColor1;
                args.Target.ColorSwappedIn2 = SkinColor2;
                args.Handled = true;
            }
        }
    }
}
