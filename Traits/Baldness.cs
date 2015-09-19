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

        //ProfileCardScreen.SetPlayerStyle - Hide hair part
        //LoadingScreen.OnEnter - Set loading text to 'Balding'
        //PlayerObj.ChangeSprite - Hide hair part
        //CreditsScreen.SetPlayerStyle - Hide hair part
    }
}
