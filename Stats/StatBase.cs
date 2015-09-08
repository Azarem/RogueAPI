using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Stats
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StatValue
    {
        public int BaseValue;
        public float Multiplier;

        public int Total
        {
            get
            {
                return (int)(BaseValue * Multiplier);
            }
        }
    }
}
