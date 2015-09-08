using DS2DEngine;
using RogueAPI.Game;
using RogueAPI.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI.Spells
{
    public class SpellDefinition
    {
        public static readonly SpellDefinition None = new SpellDefinition(0);
        internal static readonly Dictionary<byte, SpellDefinition> Lookup = new Dictionary<byte, SpellDefinition>() { { 0, None } };


        protected byte spellId;
        protected string name, displayName, description, icon;
        protected int manaCost, rarity;
        protected float damageMultiplier;
        protected float miscValue1, miscValue2;
        protected ProjectileDefinition baseProjectile;

        public byte SpellId { get { return spellId; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string DisplayName { get { return displayName; } set { displayName = value; } }
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

        public virtual ProjectileInstance GetProjectileInstance(GameObj source)
        {
            var inst = Projectile.CreateInstance(source);
            //Make sure the damage shield has the correct target (is this necessary?)
            if (SpellId == 11)
                inst.Target = source;
            return inst;
        }

        public virtual void BeginCastSpell(Entity source)
        {

        }

        public virtual void CastSpell(Entity source, bool isMega)
        {
            //Color white = Color.White;
            //ProjectileInstance projData = GetProjectileInstance(source);
            ////float damageMultiplier = ;
            //int damage = (int)(source.TotalMagicDamage * this.DamageMultiplier);
            //int manaCost = (int)(this.ManaCost * source.SpellCostMultiplier);
            //float scale = 1;
            //if (isMega)
            //{
            //    manaCost *= 2;
            //    scale *= 1.75f;
            //    damage *= 2;
            //}

            //if (source.CurrentMana >= manaCost)
            //{
            //    source.SpellCastDelay = 0.5f;
            //    if (!(this.AttachedLevel.CurrentRoom is CarnivalShoot1BonusRoom) && !(this.AttachedLevel.CurrentRoom is CarnivalShoot2BonusRoom) && (Game.PlayerStats.Traits.X == 31f || Game.PlayerStats.Traits.Y == 31f) && Game.PlayerStats.Class != 16 && Game.PlayerStats.Class != 17)
            //    {
            //        byte[] spellList = ClassType.GetSpellList(Game.PlayerStats.Class);
            //        do
            //        {
            //            Game.PlayerStats.Spell = spellList[CDGMath.RandomInt(0, (int)spellList.Length - 1)];
            //        }
            //        while (Game.PlayerStats.Spell == 6 || Game.PlayerStats.Spell == 4 || Game.PlayerStats.Spell == 11);
            //        this.AttachedLevel.UpdatePlayerSpellIcon();
            //    }
            //}
            //float xValue = SpellEV.GetXValue(spell);
            //float yValue = SpellEV.GetYValue(spell);
            //if (source.CurrentMana < manaCost)
            //{
            //    SoundManager.PlaySound("Error_Spell");
            //}
            //else if (spell != 6 && spell != 5 && !this.m_damageShieldCast && manaCost > 0)
            //{
            //    TextManager textManager = this.m_levelScreen.TextManager;
            //    Color skyBlue = Color.SkyBlue;
            //    float x = base.X;
            //    Rectangle bounds = this.Bounds;
            //    textManager.DisplayNumberStringText(-manaCost, "mp", skyBlue, new Vector2(x, (float)bounds.Top));
            //}
            //if (spell != 12 && spell != 11 && (Game.PlayerStats.Traits.X == 22f || Game.PlayerStats.Traits.Y == 22f))
            //{
            //    projData.SourceAnchor = new Vector2(projData.SourceAnchor.X * -1f, projData.SourceAnchor.Y);
            //}
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


        public static IEnumerable<SpellDefinition> All { get { return Lookup.Values; } }
    }
}
