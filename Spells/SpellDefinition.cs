using System;
using System.Collections.Generic;
using System.Linq;
using DS2DEngine;
using RogueAPI.Classes;
using RogueAPI.Game;
using RogueAPI.Projectiles;
using RogueAPI.Traits;
using RogueAPI.Stats;
using Microsoft.Xna.Framework;

namespace RogueAPI.Spells
{
    public class SpellDefinition : ILinkContainer<SpellDefinition, TraitDefinition>, ILinkContainer<SpellDefinition, ClassDefinition>
    {
        public static readonly SpellDefinition None = new SpellDefinition(0);
        internal static readonly Dictionary<byte, SpellDefinition> Lookup = new Dictionary<byte, SpellDefinition>() { };


        protected byte spellId;
        protected string name, displayName, description, icon;
        protected int manaCost, rarity;
        protected float damageMultiplier;
        //protected float miscValue1, miscValue2;
        //protected ProjectileDefinition baseProjectile;
        protected string[] soundList;
        protected bool firesProjectile;
        protected bool toggle;
        protected float manaDrainAmount;
        protected float manaDrainTime;
        protected float manaDrainCounter;
        protected float castDelay = 0.5f;
        protected float castDelayCounter = 0;
        protected bool isActive;
        protected bool showManaText = true;
        public readonly LinkedList<SpellDefinition, TraitDefinition> TraitConflicts;
        public readonly LinkedList<SpellDefinition, ClassDefinition> AssignedClasses;

        public bool CanEffectBeRotated = false;

        public byte SpellId { get { return spellId; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string DisplayName { get { return displayName; } set { displayName = value; } }
        public virtual string Description { get { return description; } set { description = value; } }
        public virtual string Icon { get { return icon; } set { icon = value; } }
        public virtual int ManaCost { get { return manaCost; } set { manaCost = value; } }
        public virtual int Rarity { get { return rarity; } set { rarity = value; } }
        public virtual float DamageMultiplier { get { return damageMultiplier; } set { damageMultiplier = value; } }
        //public virtual string[] SoundList { get { return soundList; } set { soundList = value; } }

        //This should be class dependent, and it will likely change
        //public virtual float MiscValue1 { get { return miscValue1; } set { miscValue1 = value; } }
        //public virtual float MiscValue2 { get { return miscValue2; } set { miscValue2 = value; } }
        //public virtual ProjectileDefinition Projectile { get { return baseProjectile; } set { baseProjectile = value; } }
        //public virtual bool FiresProjectile { get { return firesProjectile; } set { firesProjectile = value; } }
        //public virtual float CastDelay { get { return castDelay; } set { castDelay = value; } }

        //public SpellDefinition() { }

        public SpellDefinition(byte id)
        {
            spellId = id;
            icon = "DaggerIcon_Sprite";
            displayName = "";
            description = "";
            //baseProjectile = new ProjectileDefinition
            //{
            //    SpriteName = "BoneProjectile_Sprite",
            //    SourceAnchor = Vector2.Zero,
            //    Speed = new Vector2(0f, 0f),
            //    IsWeighted = false,
            //    RotationSpeed = 0f,
            //    Damage = 0,
            //    AngleOffset = 0f,
            //    CollidesWithTerrain = false,
            //    Scale = Vector2.One,
            //    ShowIcon = false
            //};
            TraitConflicts = new LinkedList<SpellDefinition, TraitDefinition>(this);
            AssignedClasses = new LinkedList<SpellDefinition, ClassDefinition>(this);
        }

        public virtual void Attach(Player player)
        {
            castDelayCounter = 0;
            Event<InputEventHandler>.Handler += InputHandler;
            Event<PlayerUpdateEvent>.Handler += UpdateHandler;
        }

        public virtual void Detach(Player player)
        {
            Event<PlayerUpdateEvent>.Handler += UpdateHandler;
            Event<InputEventHandler>.Handler -= InputHandler;
            castDelayCounter = 0;
        }

        public void InputHandler(InputEventHandler args)
        {
            if ((args.NewlyPressed & InputFlags.PlayerSpell1) != 0)
                Cast(Player.instance);
        }

        public override string ToString() { return Name; }

        //public virtual ProjectileInstance GetProjectileInstance(GameObj source)
        //{
        //    var inst = Projectile.CreateInstance(source);
        //    //Make sure the damage shield has the correct target (is this necessary?)
        //    if (SpellId == 11)
        //        inst.Target = source;


        //    return inst;
        //}

        internal protected virtual int GetManaCost(Entity source)
        {
            var manaCost = source.GetStatObject(ManaCostStat.Id);
            return (int)(ManaCost * manaCost.MaxValue);
        }

        public void Cast(Entity source)
        {
            if (toggle && isActive)
            {
                Deactivate();
                return;
            }

            if (castDelayCounter > 0)
                return;

            var mana = source.GetStatObject(ManaStat.Id);
            var totalCost = GetManaCost(source);

            if (mana.CurrentValue >= totalCost)
            {
                if (OnCast(source))
                {
                    mana.CurrentValue -= totalCost;

                    castDelayCounter = castDelay;

                    if (soundList != null)
                        SoundManager.PlaySound(soundList);

                    if (showManaText)
                        Core.DisplayNumberString(-totalCost, "mp", Color.SkyBlue, new Vector2(source.GameObject.X, source.GameObject.Bounds.Top));

                    if (toggle)
                    {
                        isActive = true;
                        manaDrainCounter = 0;
                    }
                }
            }
            else
                SoundManager.PlaySound("Error_Spell");
        }


        protected virtual bool OnCast(Entity source)
        {
            return true;
        }

        protected virtual void UpdateHandler(PlayerUpdateEvent evt)
        {
            if (toggle && isActive && manaDrainAmount != 0)
                DrainMana(evt);

            if (castDelayCounter > 0)
                castDelayCounter -= evt.ElapsedSeconds;
        }

        protected virtual void DrainMana(PlayerUpdateEvent evt)
        {
            manaDrainCounter += evt.ElapsedSeconds;
            if (manaDrainCounter >= manaDrainTime)
            {
                manaDrainCounter = 0;

                var mana = evt.Player.GetStatObject(ManaStat.Id);
                mana.CurrentValue -= manaDrainAmount;

                if (mana.CurrentValue <= 0)
                    Deactivate();
            }
        }

        public bool Deactivate(bool force = false)
        {
            if (!toggle || !isActive)
                return false;

            OnDeactivate(force);

            isActive = false;
            manaDrainCounter = 0;
            return true;
        }

        protected virtual void OnDeactivate(bool force) { }

        //internal protected virtual void UpdateProjectile(ProjectileObj proj, GameTime gameTime)
        //{

        //}

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
