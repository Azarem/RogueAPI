using DS2DEngine;
using RogueAPI.Game;
using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Baldness : TraitDefinition
    {
        public const byte Id = 8;
        public static Baldness Instance = new Baldness();

        protected Baldness()
            : base(Id)
        {
            this.DisplayName = "Baldness";
            this.Description = "The bald and the beautiful.";
            this.ProfileCardDescription = "You are bald.";
            this.Rarity = 1;
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Player.PlayerStyleUpdating += Player_PlayerStyleUpdating;
        }


        protected internal override void Deactivate(Player player)
        {
            Player.PlayerStyleUpdating -= Player_PlayerStyleUpdating;
            base.Deactivate(player);
        }

        private void Player_PlayerStyleUpdating(ObjContainer player, string animationType)
        {
            player.GetChildAt(7).Visible = false;
        }

        //ProfileCardScreen.SetPlayerStyle - Hide hair part
        //LoadingScreen.OnEnter - Set loading text to 'Balding'
        //PlayerObj.ChangeSprite - Hide hair part
        //CreditsScreen.SetPlayerStyle - Hide hair part
    }
}
