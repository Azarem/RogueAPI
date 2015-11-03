using DS2DEngine;
using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Dwarfism : TraitDefinition
    {
        public const byte Id = 7;
        public static readonly Dwarfism Instance = new Dwarfism();

        protected Dwarfism()
            : base(Id)
        {
            this.DisplayName = "Dwarfism";
            this.Description = "You never get to ride rollercoasters.";
            this.ProfileCardDescription = "You are tiny.";
            this.Rarity = 1;

            this.TraitConflicts.Add(Gigantism.Instance);
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Event<LevelEnterEventArgs>.Handler += LevelScreenEntered;
        }

        protected internal override void Deactivate(Player player)
        {
            Event<LevelEnterEventArgs>.Handler -= LevelScreenEntered;
            base.Deactivate(player);
        }

        private void LevelScreenEntered(LevelEnterEventArgs args)
        {
            args.Player.Scale *= 0.675f;
        }

        //ProceduralLevelScreen.OnEnter - Set player scale to 1.35
        //ProfileCasdScreen.SetPlayerStyle - Set sprite scale to 1.35
        //PlayerObj.InputControls - Play higher pitched jump sounds
        //PlayerObj.Update - Update higher pitched walk sounds
        //PlayerObj.CheckGroundCollision - Play higher pitch landing sound
        //PlayerObj.CollisionResponse - Prevent collision for left / right blocks
        //CreditsScreen.SetPlayerStyle - Set sprite scale to 1.35

    }
}
