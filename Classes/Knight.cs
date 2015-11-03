using System;
using System.Linq;
using RogueAPI.Spells;
using DS2DEngine;
using RogueAPI.Game;

namespace RogueAPI.Classes
{
    public class Knight : ClassDefinition
    {
        public const byte Id = 0;
        public static readonly Knight Instance = new Knight();

        private Knight() : this(Id) { }

        protected Knight(byte id)
            : base(id)
        {
            this.DisplayName = "Knight";
            this.Description = "Your standard hero. Pretty good at everything.";
            this.ProfileCardDescription = "100% Base stats.";

            this.AssignedSpells.Add(SpellDefinition.GetById(2));
            this.AssignedSpells.Add(SpellDefinition.GetById(1));
            this.AssignedSpells.Add(SpellDefinition.GetById(8));
            this.AssignedSpells.Add(SpellDefinition.GetById(9));
            this.AssignedSpells.Add(SpellDefinition.GetById(10));
            this.AssignedSpells.Add(SpellDefinition.GetById(12));
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Game.Player.PlayerStyleUpdating += Player_PlayerStyleUpdating;
        }


        protected internal override void Deactivate(Player player)
        {
            Game.Player.PlayerStyleUpdating -= Player_PlayerStyleUpdating;
            base.Deactivate(player);
        }

        private void Player_PlayerStyleUpdating(ObjContainer player, string animationType)
        {
            player.GetChildAt(15).Visible = true;
            player.GetChildAt(15).ChangeSprite("Player" + animationType + "Shield_Sprite");
        }
    }
}
