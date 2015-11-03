using System;
using System.Collections.Generic;
using System.Linq;
using DS2DEngine;
using RogueAPI.Classes;
using RogueAPI.Game;
using RogueAPI.Projectiles;
using RogueAPI.Traits;
using RogueAPI.Stats;

namespace RogueAPI.Spells
{
    public class SpellDefinition : ILinkContainer<SpellDefinition, TraitDefinition>, ILinkContainer<SpellDefinition, ClassDefinition>
    {
        public static readonly SpellDefinition None = new SpellDefinition(0);
        internal static readonly Dictionary<byte, SpellDefinition> Lookup = new Dictionary<byte, SpellDefinition>() { { 0, None } };


        protected byte spellId;
        protected string name, displayName, description, icon;
        protected int manaCost, rarity;
        protected float damageMultiplier;
        protected float miscValue1, miscValue2;
        protected ProjectileDefinition baseProjectile;
        protected string[] soundList;
        public readonly LinkedList<SpellDefinition, TraitDefinition> TraitConflicts;
        public readonly LinkedList<SpellDefinition, ClassDefinition> AssignedClasses;

        public byte SpellId { get { return spellId; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string DisplayName { get { return displayName; } set { displayName = value; } }
        public virtual string Description { get { return description; } set { description = value; } }
        public virtual string Icon { get { return icon; } set { icon = value; } }
        public virtual int ManaCost { get { return manaCost; } set { manaCost = value; } }
        public virtual int Rarity { get { return rarity; } set { rarity = value; } }
        public virtual float DamageMultiplier { get { return damageMultiplier; } set { damageMultiplier = value; } }
        public virtual string[] SoundList { get { return soundList; } set { soundList = value; } }

        //This should be class dependent, and it will likely change
        public virtual float MiscValue1 { get { return miscValue1; } set { miscValue1 = value; } }
        public virtual float MiscValue2 { get { return miscValue2; } set { miscValue2 = value; } }
        public virtual ProjectileDefinition Projectile { get { return baseProjectile; } set { baseProjectile = value; } }

        //public SpellDefinition() { }

        public SpellDefinition(byte id)
        {
            this.spellId = id;
            TraitConflicts = new LinkedList<SpellDefinition, TraitDefinition>(this);
            AssignedClasses = new LinkedList<SpellDefinition, ClassDefinition>(this);
        }

        public override string ToString() { return Name; }

        public virtual ProjectileInstance GetProjectileInstance(GameObj source)
        {
            var inst = Projectile.CreateInstance(source);
            //Make sure the damage shield has the correct target (is this necessary?)
            if (SpellId == 11)
                inst.Target = source;
            return inst;
        }

        internal protected virtual void BeginCastSpell(Entity source)
        {
            var mana = source.GetStatObject(ManaStat.Id);
            var manaCost = source.GetStatObject(ManaCostStat.Id);

            var totalCost = ManaCost * manaCost.MaxValue;

            if(mana.CurrentValue >= totalCost)
            {
                mana.CurrentValue -= totalCost;
                CastSpell(source, null, false);
            }
        }

        protected virtual void CastSpell(Entity source, ProjectileObj projectile, bool isMega)
        {

        }


        public static SpellDefinition Register(SpellDefinition def) { return Lookup[def.SpellId] = def; }
        public static SpellDefinition Register(byte id) { return Register(new SpellDefinition(id)); }


        public static SpellDefinition GetById(byte id)
        {
            SpellDefinition def;
            if (!Lookup.TryGetValue(id, out def))
                def = None;
            return def;
        }

        public static SpellDefinition GetRandomSpell(ClassDefinition cls, TraitDefinition[] traits)
        {
            var spellList = cls.AssignedSpells.Where(x => !traits.Any(y => y.SpellConflicts.Contains(x))).ToList();
            return spellList[CDGMath.RandomInt(0, spellList.Count - 1)];
        }


        public static IEnumerable<SpellDefinition> All { get { return Lookup.Values; } }

        LinkedList<SpellDefinition, TraitDefinition> ILinkContainer<SpellDefinition, TraitDefinition>.LinkedList { get { return TraitConflicts; } }
        LinkedList<SpellDefinition, ClassDefinition> ILinkContainer<SpellDefinition, ClassDefinition>.LinkedList { get { return AssignedClasses; } }
    }
}
