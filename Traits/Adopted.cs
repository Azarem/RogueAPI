using System;
using System.Linq;

namespace RogueAPI.Traits
{
    public class Adopted : TraitDefinition
    {
        public const byte Id = 100;
        public static readonly Adopted Instance = new Adopted();

        protected Adopted()
            : base(Id)
        {

        }
    }
}
