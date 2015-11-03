using System;
using System.Collections.Generic;
using System.Linq;
using RogueAPI.Classes;
using RogueAPI.Spells;
using DS2DEngine;
using RogueAPI.Game;

namespace RogueAPI.Traits
{
    public class TraitDefinition : ILinkContainer<TraitDefinition, TraitDefinition>, ILinkContainer<TraitDefinition, ClassDefinition>, ILinkContainer<TraitDefinition, SpellDefinition>
    {
        public readonly byte TraitId;
        //public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual string FemaleDescription { get; set; }
        public virtual string ProfileCardDescription { get; set; }
        public virtual string FemaleProfileCardDescription { get; set; }
        public virtual byte Rarity { get; set; }

        public readonly LinkedList<TraitDefinition, TraitDefinition> TraitConflicts;
        public readonly LinkedList<TraitDefinition, ClassDefinition> ClassConflicts;
        public readonly LinkedList<TraitDefinition, SpellDefinition> SpellConflicts;

        public TraitDefinition(byte id)
        {
            TraitId = id;
            TraitConflicts = new LinkedList<TraitDefinition, TraitDefinition>(this);
            ClassConflicts = new LinkedList<TraitDefinition, ClassDefinition>(this);
            SpellConflicts = new LinkedList<TraitDefinition, SpellDefinition>(this);
        }

        public string GetProfileDescription(bool isFemale = false)
        {
            return isFemale ? (FemaleProfileCardDescription ?? FemaleDescription ?? ProfileCardDescription ?? Description) : (ProfileCardDescription ?? Description);
        }

        public string GetDescription(bool isFemale = false)
        {
            return isFemale ? (FemaleDescription ?? Description) : Description;
        }

        internal protected virtual void Activate(Player player)
        {

        }

        internal protected virtual void Deactivate(Player player)
        {

        }

        LinkedList<TraitDefinition, ClassDefinition> ILinkContainer<TraitDefinition, ClassDefinition>.LinkedList { get { return ClassConflicts; } }
        LinkedList<TraitDefinition, TraitDefinition> ILinkContainer<TraitDefinition, TraitDefinition>.LinkedList { get { return TraitConflicts; } }
        LinkedList<TraitDefinition, SpellDefinition> ILinkContainer<TraitDefinition, SpellDefinition>.LinkedList { get { return SpellConflicts; } }

        #region Statics

        public static readonly Dictionary<byte, TraitDefinition> All = new Dictionary<byte, TraitDefinition>() { 
            {ColorBlind.Id, ColorBlind.Instance},
            {Gay.Id, Gay.Instance},
            {NearSighted.Id, NearSighted.Instance},
            {FarSighted.Id, FarSighted.Instance},
            {Dyslexia.Id, Dyslexia.Instance},
            {Gigantism.Id, Gigantism.Instance},
            {Dwarfism.Id, Dwarfism.Instance},
            {Baldness.Id, Baldness.Instance},
            {Endomorph.Id, Endomorph.Instance},
            {Ectomorph.Id, Ectomorph.Instance},
            {Alzheimers.Id, Alzheimers.Instance},
            {Dextrocardia.Id, Dextrocardia.Instance},
            {Tourettes.Id, Tourettes.Instance},
            {Hyperactive.Id, Hyperactive.Instance},
            {OCD.Id, OCD.Instance},
            {Hypergonadism.Id, Hypergonadism.Instance},
            {Hypogonadism.Id, Hypogonadism.Instance},
            {StereoBlind.Id, StereoBlind.Instance},
            {IBS.Id, IBS.Instance},
            {Vertigo.Id, Vertigo.Instance},
            {TunnelVision.Id, TunnelVision.Instance},
            {Ambilevous.Id, Ambilevous.Instance},
            {PAD.Id, PAD.Instance},
            {Alektorophobia.Id, Alektorophobia.Instance},
            {Hypochondriac.Id, Hypochondriac.Instance},
            {Dementia.Id, Dementia.Instance},
            {Hypermobility.Id, Hypermobility.Instance},
            {EideticMemory.Id, EideticMemory.Instance},
            {Nostalgic.Id, Nostalgic.Instance},
            {CIP.Id, CIP.Instance},
            {Savant.Id, Savant.Instance},
            {TheOne.Id, TheOne.Instance},
            {NoFurniture.Id, NoFurniture.Instance},
            {PlatformsOpen.Id, PlatformsOpen.Instance},
            {Glaucoma.Id, Glaucoma.Instance}
        };


        public static TraitDefinition Register(TraitDefinition trait)
        {
            All[trait.TraitId] = trait;
            return trait;
        }

        public static TraitDefinition GetById(byte id) { return All[id]; }


        public static TraitDefinition[] CreateRandomTraits(ClassDefinition cls)
        {
            int traitCount = 0;

            int rand = CDGMath.RandomInt(0, 100);
            if (rand < 94)
                traitCount++;
            if (rand < 55)
                traitCount++;

            var traits = new List<TraitDefinition>(traitCount);
            while (traitCount-- > 0)
            {
                rand = CDGMath.RandomInt(0, 100);
                int rarity = 1;
                if (rand > 48)
                    rarity++;
                if (rand > 85)
                    rarity++;

                while (rarity > 0)
                {
                    var avail = TraitDefinition.All.Values.Where(x => x.Rarity == rarity && !traits.Contains(x) && !x.ClassConflicts.Contains(cls)).ToList();
                    if (avail.Count > 0)
                    {
                        traits.Add(avail[CDGMath.RandomInt(0, avail.Count)]);
                        break;
                    }
                    rarity--;
                }
            }

            return traits.ToArray();
        }

        #endregion
    }
}
