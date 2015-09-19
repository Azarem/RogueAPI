using System;
using System.Linq;
using DS2DEngine;

namespace RogueAPI.Screens
{
    public class ScreenBase : Screen
    {
        internal static ScreenBase current;

        public static ScreenBase Current { get { return current; } }
    }
}
