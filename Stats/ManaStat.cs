using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Stats
{
    public class ManaStat : StatDefinition
    {
        public const byte Id = 1;

        public ManaStat()
        {
            BaseValue = 100f;
        }
    }
}
