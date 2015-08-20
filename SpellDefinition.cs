using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI
{
    public class SpellDefinition
    {
        internal static readonly Dictionary<byte, SpellDefinition> Lookup = new Dictionary<byte, SpellDefinition>();

        public static readonly SpellDefinition None = new SpellDefinition(0, "", "", "");

        protected byte spellId;
        protected string name, description, icon;

        public byte SpellId { get { return spellId; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string Description { get { return description; } set { description = value; } }
        public virtual string Icon { get { return icon; } set { icon = value; } }

        public SpellDefinition() { }

        public SpellDefinition(byte id, string name = "", string description = "", string icon = "")
        {
            this.spellId = id;
            this.name = name;
            this.description = description;
            this.icon = icon;
        }

        public static void Register(SpellDefinition def) { Lookup[def.SpellId] = def; }
        public static SpellDefinition Register(byte id, string name = "", string description = "", string icon = "")
        {
            var def = new SpellDefinition(id, name, description, icon);
            Register(def);
            return def;
        }


        public static SpellDefinition GetById(byte id)
        {
            SpellDefinition def;
            if (!Lookup.TryGetValue(id, out def))
                def = None;
            return def;
        }

        public static IEnumerable<SpellDefinition> All { get { return Lookup.Values; } }
    }
}
