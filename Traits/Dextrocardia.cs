using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Dextrocardia : TraitDefinition
    {
        public const byte Id = 12;
        public static readonly Dextrocardia Instance = new Dextrocardia();

        protected Dextrocardia()
            : base(Id)
        {
            this.DisplayName = "Dextrocardia";
            this.Description = "Your MP and HP pools are swapped.  Who knew?";
            this.ProfileCardDescription = "MP + HP pools swapped.";
            this.Rarity = 2;

            this.ClassConflicts.Add(Classes.Lich.Instance);
            this.ClassConflicts.Add(Classes.LichKing.Instance);
        }

        //PlayerHUDObj.SetPosition - Swap position of HP / MP bars
        //PlayerObj.MaxHealth - Retrieve max mana
        //PlayerObj.MaxMana - retrieve max health
    }
}
