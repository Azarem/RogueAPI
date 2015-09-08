using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Stats
{
    public interface IStat
    {
        int Base { get; }
        float Multiplier { get; }
        int Total { get; }
    }
}
