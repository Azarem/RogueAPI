using System;
using System.Collections.Generic;
using System.Linq;
using RogueAPI.Spells;
using RogueAPI.Traits;
using RogueAPI.Stats;
using RogueAPI.Game;

namespace RogueAPI.Classes
{
    public class ClassDefinition : ILinkContainer<ClassDefinition, TraitDefinition>, ILinkContainer<ClassDefinition, SpellDefinition>
    {
        internal static readonly Dictionary<byte, ClassDefinition> All = new Dictionary<byte, ClassDefinition>() { 
            {Knight.Id, Knight.Instance},
            {Mage.Id, Mage.Instance},
            {Barbarian.Id, Barbarian.Instance},
            {Knave.Id, Knave.Instance},
            {Shinobi.Id, Shinobi.Instance},
            {Miner.Id, Miner.Instance},
            {Spellthief.Id, Spellthief.Instance},
            {Lich.Id, Lich.Instance},
            {Paladin.Id, Paladin.Instance},
            {Archmage.Id, Archmage.Instance},
            {BarbarianKing.Id, BarbarianKing.Instance},
            {Assassin.Id, Assassin.Instance},
            {Hokage.Id, Hokage.Instance},
            {Spelunker.Id, Spelunker.Instance},
            {Spellsword.Id, Spellsword.Instance},
            {LichKing.Id, LichKing.Instance}
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

        internal protected virtual void Activate(Player player)
        {
            player.GetStatObject(HealthStat.Id).AddHandler(CalculatingMaxHealth);
            player.GetStatObject(ManaStat.Id).AddHandler(CalculatingMaxMana);
        }

        internal protected virtual void Deactivate(Player player)
        {
            player.GetStatObject(ManaStat.Id).RemoveHandler(CalculatingMaxMana);
            player.GetStatObject(HealthStat.Id).RemoveHandler(CalculatingMaxHealth);
        }

        protected virtual void CalculatingMaxHealth(StatCalculation calc)
        {
            calc.Multiplier *= HealthMultiplier;
        }

        protected virtual void CalculatingMaxMana(StatCalculation calc)
        {
            calc.Multiplier *= ManaMultiplier;
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
