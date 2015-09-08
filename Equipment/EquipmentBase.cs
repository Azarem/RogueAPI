using Microsoft.Xna.Framework;
using RogueAPI.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Equipment
{
    public class EquipmentBase //: AttachmentBase
    {
        public int CategoryId;
        public int Index;
        public string DisplayName;
        public string ShortDisplayName;
        public int Cost = 9999;
        public int Weight;
        public int BonusHealth;
        public int BonusDamage;
        public int BonusMagic;
        public int BonusMana;
        public int BonusArmor;
        public byte LevelRequirement;
        public byte ChestColourRequirement;
        public Color FirstColour = Color.White;
        public Color SecondColour = Color.White;
        public Vector2[] SecondaryAttribute;

        public EquipmentBase() { }

        public void Dispose() { }

        //public static EquipmentBase operator -(EquipmentBase first, EquipmentBase second)
        //{
        //    return new EquipmentBase()
        //    {
        //        Weight = first.Weight - second.Weight,
        //        BonusHealth = first.BonusHealth - second.BonusHealth,
        //        BonusDamage = first.BonusDamage - second.BonusDamage,
        //        BonusArmor = first.BonusArmor - second.BonusArmor,
        //        BonusMagic = first.BonusMagic - second.BonusMagic,
        //        BonusMana = first.BonusMana - second.BonusMana
        //    };
        //}
    }
}
