using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI
{
    public static class Core
    {
        public static event Action ContentLoaded;

        public static void Initialize()
        {
            //Perform other initialization here

            //Load plugins
            Plugins.PluginInitializer.Initialize();
        }

        public static void OnContentLoaded()
        {
            if (ContentLoaded != null)
                ContentLoaded();
        }
    }
}
