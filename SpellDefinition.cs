using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI
{
    public class SpellDefinition
    {
        internal static readonly Dictionary<byte, SpellDefinition> Lookup = new Dictionary<byte, SpellDefinition>();

        public static readonly SpellDefinition None = new SpellDefinition(0) { Name = "", Description = "", Icon = "" };

        protected byte spellId;
        protected string name, description, icon;
        protected int manaCost, rarity;
        protected float damageMultiplier;
        protected float miscValue1, miscValue2;
        protected ProjectileDefinition baseProjectile;

        public byte SpellId { get { return spellId; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string Description { get { return description; } set { description = value; } }
        public virtual string Icon { get { return icon; } set { icon = value; } }
        public virtual int ManaCost { get { return manaCost; } set { manaCost = value; } }
        public virtual int Rarity { get { return rarity; } set { rarity = value; } }
        public virtual float DamageMultiplier { get { return damageMultiplier; } set { damageMultiplier = value; } }

        //This should be class dependent, and it will likely change
        public virtual float MiscValue1 { get { return miscValue1; } set { miscValue1 = value; } }
        public virtual float MiscValue2 { get { return miscValue2; } set { miscValue2 = value; } }
        public virtual ProjectileDefinition Projectile { get { return baseProjectile; } set { baseProjectile = value; } }

        //public SpellDefinition() { }

        public SpellDefinition(byte id)
        {
            this.spellId = id;
        }

        public override string ToString() { return Name; }

        public static void Register(SpellDefinition def) { Lookup[def.SpellId] = def; }
        public static SpellDefinition Register(byte id)
        {
            var def = new SpellDefinition(id);
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
