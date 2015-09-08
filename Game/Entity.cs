using DS2DEngine;
using RogueAPI.Modifiers;
using RogueAPI.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    public class Entity : GameObj
    {
        public int TotalMagicDamage { get { return 0; } }
        public float SpellCastDelay { get; set; }
        public int CurrentMana { get; set; }
        public float SpellCostMultiplier { get; set; }

        public IAttachmentCollection[] attachments;

        public readonly StatCollection Stats = new StatCollection();
        


        protected override GameObj CreateCloneInstance()
        {
            throw new NotImplementedException();
        }
    }
}
