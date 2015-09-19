using System;
using System.Collections.Generic;
using System.Linq;
using RogueAPI.Spells;
using RogueAPI.Traits;

namespace RogueAPI.Classes
{
    public class ClassDefinition : ILinkContainer<ClassDefinition, TraitDefinition>, ILinkContainer<ClassDefinition, SpellDefinition>
    {
        internal static readonly Dictionary<byte, ClassDefinition> All = new Dictionary<byte, ClassDefinition>() { 
            {Knight.Id, Knight.Instance},
            {Wizard.Id, Wizard.Instance},
            {Barbarian.Id, Barbarian.Instance},
            {Assassin.Id, Assassin.Instance},
            {Ninja.Id, Ninja.Instance},
            {Banker.Id, Banker.Instance},
            {SpellSword.Id, SpellSword.Instance},
            {Lich.Id, Lich.Instance},
            {Knight2.Id, Knight2.Instance},
            {Wizard2.Id, Wizard2.Instance},
            {Barbarian2.Id, Barbarian2.Instance},
            {Assassin2.Id, Assassin2.Instance},
            {Ninja2.Id, Ninja2.Instance},
            {Banker2.Id, Banker2.Instance},
            {SpellSword2.Id, SpellSword2.Instance},
            {Lich2.Id, Lich2.Instance}
        };

        //public static readonly ClassDefinition None = null;

        private byte classId;
        protected float healthMultiplier = 1.0f;
        protected float manaMultiplier = 1.0f;
        protected float moveSpeedMultiplier = 0f;
        protected float magicDamageMultiplier = 1.0f;
        protected float physicalDamageMultiplier = 1.0f;
        protected float damageTakenMultiplier = 1.0f;
        protected float goldBonus = 0.0f;
        protected float criticalChanceBonus = 0f;
        protected float criticalChanceMultiplier = 1f;
        protected float criticalDamageBonus = 0f;
        protected int manaGainBonus = 0;
        protected string name, displayName, femaleDisplayName;
        protected string description, profileDescription;

        public readonly LinkedList<ClassDefinition, SpellDefinition> AssignedSpells;
        public readonly LinkedList<ClassDefinition, TraitDefinition> TraitConflicts;

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
        public virtual float GoldBonus { get { return goldBonus; } set { goldBonus = value; } }
        public virtual float CriticalChanceBonus { get { return criticalChanceBonus; } set { criticalChanceBonus = value; } }
        public virtual float CriticalChanceMultiplier { get { return criticalChanceMultiplier; } set { criticalChanceMultiplier = value; } }
        public virtual float CriticalDamageBonus { get { return criticalDamageBonus; } set { criticalDamageBonus = value; } }
        public virtual int ManaGainBonus { get { return manaGainBonus; } set { manaGainBonus = value; } }
        //public virtual string FemaleProfileCardDescription { get; set; }

        public ClassDefinition(byte id)
        {
            classId = id;
            TraitConflicts = new LinkedList<ClassDefinition, TraitDefinition>(this);
            AssignedSpells = new LinkedList<ClassDefinition, SpellDefinition>(this);
        }

        internal protected virtual void Activate()
        {

        }

        internal protected virtual void Deactivate()
        {

        }


        public static ClassDefinition Register(ClassDefinition def) { All[def.ClassId] = def; return def; }
        public static ClassDefinition Register(byte id)
        {
            var def = new ClassDefinition(id);
            Register(def);
            return def;
        }

        public byte[] SpellByteArray { get { return AssignedSpells.Select(x => x.SpellId).ToArray(); } }

        public override string ToString()
        {
            return Name;
        }

        public static ClassDefinition GetById(byte id)
        {
            ClassDefinition def;
            if (!All.TryGetValue(id, out def))
                return null;
            return def;
        }

        public string GetDisplayName(bool isFemale)
        {
            return isFemale ? (FemaleDisplayName ?? DisplayName) : (DisplayName ?? FemaleDisplayName);
        }
        public string GetProfileCardDescription()
        {
            return (ProfileCardDescription ?? Description);
        }


        //public static IEnumerable<ClassDefinition> All { get { return Lookup.Values; } }

        LinkedList<ClassDefinition, TraitDefinition> ILinkContainer<ClassDefinition, TraitDefinition>.LinkedList { get { return TraitConflicts; } }
        LinkedList<ClassDefinition, SpellDefinition> ILinkContainer<ClassDefinition, SpellDefinition>.LinkedList { get { return AssignedSpells; } }
    }
}
