using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Savant : TraitDefinition
    {
        public const byte Id = 31;
        public static readonly Savant Instance = new Savant();

        protected Savant()
            : base(Id)
        {
            this.DisplayName = "Savant";
            this.Description = "You're very talented. With a few issues.";
            this.ProfileCardDescription = "Randomized spells.";
            this.Rarity = 2;

            this.ClassConflicts.Add(Classes.Wizard.Instance);
            this.ClassConflicts.Add(Classes.Wizard2.Instance);
            this.ClassConflicts.Add(Classes.Dragon.Instance);
        }
    }
}
