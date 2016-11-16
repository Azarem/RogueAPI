using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class InitializeAttribute : Attribute
    {
        public static void ProcessAll()
        {
            var attrType = typeof(InitializeAttribute);
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => x.CustomAttributes.Any(y => y.AttributeType == attrType)))
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        }

        public InitializeAttribute()
        {

        }
    }
}
