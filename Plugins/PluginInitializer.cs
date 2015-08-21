using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Plugins
{
    public static class PluginInitializer
    {
        internal static List<Assembly> _pluginAssemblies = new List<Assembly>();

        public static void Initialize()
        {
            //Find / create plugin directory
            var root = new DirectoryInfo("Plugins");
            if (!root.Exists)
                root.Create();

            var dirs = root.EnumerateDirectories().ToList();
            var dlls = root.EnumerateFiles("*.dll", SearchOption.AllDirectories).ToList();


            Console.WriteLine("PLUGINS: Found {0} dlls in plugin directory", dlls.Count);

            //Look for existing .dll files
            foreach (var f in dlls)
            {
                var srcDir = dirs.FirstOrDefault(x => x.Name == Path.GetFileNameWithoutExtension(f.Name));
                if (srcDir != null && srcDir.LastWriteTime <= f.LastWriteTime)
                    dirs.Remove(srcDir);
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters(new string[] { typeof(PluginInitializer).Assembly.Location })
            {
                GenerateInMemory = false,
                GenerateExecutable = false,
                IncludeDebugInformation = false
            };

            Console.WriteLine("PLUGINS: Processing {0} source folders in plugin directory", dirs.Count);

            foreach (var f in dirs)
            {
                try
                {
                    parameters.OutputAssembly = Path.Combine(root.FullName, f.Name + ".dll");
                    var results = provider.CompileAssemblyFromFile(parameters, f.EnumerateFiles("*.cs", SearchOption.AllDirectories).Select(x => x.FullName).ToArray());
                    Console.WriteLine("PLUGINS: Compilation from {0}: {1} errors {2}", parameters.OutputAssembly, results.Errors.Count, String.Join("\r\n", results.Errors.Cast<CompilerError>()));

                    if (!results.Errors.HasErrors)
                        _pluginAssemblies.Add(results.CompiledAssembly);
                }
                catch (Exception x)
                {
                    Console.WriteLine("PLUGINS: {0}", x);
                }
            }

            foreach (var d in dlls)
            {
                try
                {
                    _pluginAssemblies.Add(Assembly.LoadFrom(d.FullName));
                }
                catch (Exception x)
                {
                    Console.WriteLine("PLUGINS: {0}", x);
                }
            }

            foreach (var a in _pluginAssemblies)
            {
                var entry = a.GetCustomAttribute<PluginEntryPointAttribute>();
                if (entry != null)
                    Activator.CreateInstance(entry._type);
            }
        }
    }
}
