using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Alzheimers : TraitDefinition
    {
        public const byte Id = 11;
        public static readonly Alzheimers Instance = new Alzheimers();

        protected Alzheimers()
            : base(Id)
        {
            this.DisplayName = "Alzheimers";
            this.Description = "You have trouble remembering where you are.";
            this.ProfileCardDescription = "Where are you?";
            this.Rarity = 3;
        }

        private TextObj questionMarkText;

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Event<MapEnterEventArgs>.Handler += MapScreenEntered;
            Event<MapDrawEventArgs>.Handler += MapScreenDraw;
            Event<MapExitEventArgs>.Handler += MapScreenExited;
        }


        protected internal override void Deactivate(Player player)
        {
            Event<MapEnterEventArgs>.Handler -= MapScreenEntered;
            Event<MapDrawEventArgs>.Handler -= MapScreenDraw;
            Event<MapExitEventArgs>.Handler -= MapScreenExited;

            if (questionMarkText != null)
            {
                questionMarkText.Dispose();
                questionMarkText = null;
            }

            base.Deactivate(player);
        }

        private void MapScreenEntered(MapEnterEventArgs args)
        {
            questionMarkText = new TextObj(Game.Fonts.JunicodeLargeFont)
            {
                FontSize = 30f,
                ForceDraw = true,
                Text = "?????",
                Align = Types.TextAlign.Centre,
                Position = new Vector2(660f, 360f - questionMarkText.Height / 2f)
            };

            if (!args.IsTeleporter)
                args.DrawNothing = true;
        }

        private void MapScreenDraw(MapDrawEventArgs args)
        {
            if (!args.IsTeleporter)
                questionMarkText.Draw(args.Camera);
        }

        private void MapScreenExited(MapExitEventArgs args)
        {
            if (questionMarkText != null)
            {
                questionMarkText.Dispose();
                questionMarkText = null;
            }
        }

        //MapScreen.OnEnter - Set DrawNothing = true
        //MapScreen.Draw - Draw alzheimers question marks
    }
}
