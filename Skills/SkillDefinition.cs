using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Skills
{
    public class SkillDefinition
    {
        internal static readonly Dictionary<byte, SkillDefinition> All = new Dictionary<byte, SkillDefinition>() {
            {HealthUp.Id, HealthUp.Instance},
            {InvulnTimeUp.Id, InvulnTimeUp.Instance},
            {DeathDodge.Id, DeathDodge.Instance},
            {AttackUp.Id, AttackUp.Instance},
            {DownStrikeUp.Id, DownStrikeUp.Instance},
            {CritChanceUp.Id, CritChanceUp.Instance},
            {CritDamageUp.Id, CritDamageUp.Instance},
            {MagicDamageUp.Id, MagicDamageUp.Instance},
            {ManaUp.Id, ManaUp.Instance},
            {ManaCostDown.Id, ManaCostDown.Instance},
            {Smithy.Id, Smithy.Instance},
            {Enchanter.Id, Enchanter.Instance},
            {Architect.Id, Architect.Instance},
            {EquipUp.Id, EquipUp.Instance},
            {ArmorUp.Id, ArmorUp.Instance},
            {GoldGainUp.Id, GoldGainUp.Instance},
            {PricesDown.Id, PricesDown.Instance},
            {PotionUp.Id, PotionUp.Instance},
            {RandomizeChildren.Id, RandomizeChildren.Instance},
            {LichUnlock.Id, LichUnlock.Instance},
            {BankerUnlock.Id, BankerUnlock.Instance},
            {SpellswordUnlock.Id, SpellswordUnlock.Instance},
            {NinjaUnlock.Id, NinjaUnlock.Instance},
            {KnightUp.Id, KnightUp.Instance},
            {MageUp.Id, MageUp.Instance},
            {AssassinUp.Id, AssassinUp.Instance},
            {BankerUp.Id, BankerUp.Instance},
            {BarbarianUp.Id, BarbarianUp.Instance},
            {LichUp.Id, LichUp.Instance},
            {NinjaUp.Id, NinjaUp.Instance},
            {SpellswordUp.Id, SpellswordUp.Instance},
            {SuperSecret.Id, SuperSecret.Instance}
        };

        protected readonly byte skillId;
        public byte SkillId { get { return skillId; } }

        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual string InputDescription { get; set; }
        public virtual string UnitText { get; set; }
        public virtual string Icon { get; set; }
        public virtual float PerLevelModifier { get; set; }
        public virtual int BaseCost { get; set; }
        public virtual int CostIncrement { get; set; }
        public virtual int MaxLevel { get; set; }
        public virtual bool DisplayStat { get; set; }
        public virtual float ModifierTotal { get { return CurrentLevel * PerLevelModifier; } }

        private int _currentLevel;
        public virtual int CurrentLevel
        {
            get { return _currentLevel; }
            set
            {
                if (value > MaxLevel)
                    value = MaxLevel;

                if (value != _currentLevel)
                {
                    _currentLevel = value;
                    if (_currentLevel == 0)
                        Activate(Player.instance);
                    else if (value == 0)
                        Deactivate(Player.Instance);
                    else
                        LevelChanged(Player.Instance);
                }
            }
        }


        protected SkillDefinition(byte id)
        {
            skillId = id;
        }

        protected virtual void Activate(Player player)
        {

        }

        protected virtual void Deactivate(Player player)
        {

        }

        protected virtual void LevelChanged(Player player)
        {

        }

        public static SkillDefinition Register(SkillDefinition def) { All[def.SkillId] = def; return def; }
        public static SkillDefinition Register(byte id)
        {
            var def = new SkillDefinition(id);
            Register(def);
            return def;
        }

        public static SkillDefinition GetById(byte id)
        {
            SkillDefinition def;
            if (!All.TryGetValue(id, out def))
                return null;
            return def;
        }
    }
}
