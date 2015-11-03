﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Stats
{
    public class HealthStat : StatDefinition
    {
        public const byte Id = 0;

        public HealthStat()
        {
            BaseValue = 100f;
        }
    }
}
