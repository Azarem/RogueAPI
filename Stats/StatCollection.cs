using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Stats
{
    public class StatCollection
    {
        public IStat[] All;

        public IStat Health { get { return All[HealthStat.Id]; } }
        public IStat Mana { get { return All[HealthStat.Id]; } }
        public IStat Speed { get { return All[HealthStat.Id]; } }
        public IStat Defense { get { return All[HealthStat.Id]; } }
        public IStat AttackPower { get { return All[HealthStat.Id]; } }
        public IStat MagicPower { get { return All[HealthStat.Id]; } }
    }
}
