using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Spells
{
    public class SpellBase : SpellDefinition
    {
        public SpellBase(byte id) : base(id) { }
    }
}
