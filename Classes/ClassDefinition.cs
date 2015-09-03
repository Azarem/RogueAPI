using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Classes
{
    public class ClassDefinition
    {
        internal static readonly Dictionary<byte, ClassDefinition> Lookup = new Dictionary<byte, ClassDefinition>();

        //public static readonly ClassDefinition None = null;

        private byte classId;
        protected float healthMultiplier;
        protected float manaMultiplier;
        protected float moveSpeedMultiplier;
        protected float magicDamageMultiplier;
        protected float physicalDamageMultiplier;
        protected float damageTakenMultiplier;
        protected string name, displayName, femaleDisplayName;
        protected string description, profileDescription;
        protected HashSet<Spells.SpellDefinition> spellList = new HashSet<Spells.SpellDefinition>();

        public virtual byte ClassId { get { return classId; } }
        public virtual float HealthMultiplier { get { return healthMultiplier; } set { healthMultiplier = value; } }
        public virtual float ManaMultiplier { get { return manaMultiplier; } set { manaMultiplier = value; } }
        public virtual float MoveSpeedMultiplier { get { return moveSpeedMultiplier; } set { moveSpeedMultiplier = value; } }
        public virtual float MagicDamageMultiplier { get { return magicDamageMultiplier; } set { magicDamageMultiplier = value; } }
        public virtual float PhysicalDamageMultiplier { get { return physicalDamageMultiplier; } set { physicalDamageMultiplier = value; } }
        public float DamageTakenMultiplier { get { return damageTakenMultiplier; } set { damageTakenMultiplier = value; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string DisplayName { get { return displayName; } set { displayName = value; } }
        public virtual string FemaleDisplayName { get { return femaleDisplayName; } set { femaleDisplayName = value; } }
        public virtual string Description { get { return description; } set { description = value; } }
        public virtual string ProfileCardDescription { get { return profileDescription; } set { profileDescription = value; } }
        public HashSet<Spells.SpellDefinition> SpellList { get { return spellList; } }

        public ClassDefinition(byte id) { classId = id; }


        public static ClassDefinition Register(ClassDefinition def) { Lookup[def.ClassId] = def; return def; }
        public static ClassDefinition Register(byte id)
        {
            var def = new ClassDefinition(id);
            Register(def);
            return def;
        }

        public byte[] SpellByteArray { get { return SpellList.Select(x => x.SpellId).ToArray(); } }

        public override string ToString()
        {
            return Name;
        }

        public static ClassDefinition GetById(byte id)
        {
            ClassDefinition def;
            if (!Lookup.TryGetValue(id, out def))
                return null;
            return def;
        }

        public string GetDisplayName(bool isFemale)
        {
            return isFemale ? (FemaleDisplayName ?? DisplayName) : DisplayName;
        }


        public static IEnumerable<ClassDefinition> All { get { return Lookup.Values; } }
    }
}
