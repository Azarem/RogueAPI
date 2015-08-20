using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI
{
    public class SpellDefinition
    {
        public static readonly Dictionary<byte, SpellDefinition> Lookup = new Dictionary<byte, SpellDefinition>();

        protected byte spellId;
        protected string name, description, icon;

        public byte SpellId { get { return spellId; } }
        public virtual string Name { get { return name; } }
        public virtual string Description { get { return description; } }
        public virtual string Icon { get { return icon; } }

        public SpellDefinition() { }

        public SpellDefinition(byte spellId, string name, string description, string icon)
        {
            this.spellId = spellId;
            this.name = name;
            this.description = description;
            this.icon = icon;

            //Lookup[spellId] = this;
        }

        public void Register(SpellDefinition def)
        {
            Lookup[def.SpellId] = def;
        }
    }
}
