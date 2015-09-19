using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Hypogonadism : TraitDefinition
    {
        public const byte Id = 17;
        public static readonly Hypogonadism Instance = new Hypogonadism();

        protected Hypogonadism()
            : base(Id)
        {
            this.DisplayName = "Muscle Wk.";
            this.Description = "You have weak limbs.  Enemies won't get knocked back.";
            this.ProfileCardDescription = "You can't knock enemies back.";
            this.Rarity = 3;

            this.TraitConflicts.Add(Hypergonadism.Instance);
        }
    }
}
