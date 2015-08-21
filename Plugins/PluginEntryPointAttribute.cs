using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueAPI.Plugins
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class PluginEntryPointAttribute : Attribute
    {
        internal static List<PluginEntryPointAttribute> _list = new List<PluginEntryPointAttribute>();
        internal Type _type;

        public PluginEntryPointAttribute(Type t)
        {
            _type = t;
            _list.Add(this);
        }

    }
}
