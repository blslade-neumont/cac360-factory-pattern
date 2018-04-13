using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    internal class WpfRunner : CSharpRunner
    {
        public WpfRunner(IEnumerable<string> paths, string exePath)
            : base(paths, WPF_REFERENCES, exePath)
        {
        }

        public static WpfRunner FromCode(string[] compilationUnits)
        {
            var paths = new List<string>();
            foreach (var compilationUnit in compilationUnits)
            {
                var tempPath = Path.GetTempFileName();
                var path = tempPath.Replace(".tmp", ".cs");
                File.Move(tempPath, path);
                File.WriteAllText(path, compilationUnit, Encoding.UTF8);
                paths.Add(path);
            }

            var tempExePath = Path.GetTempFileName();
            var exePath = tempExePath.Replace(".tmp", ".exe");
            File.Delete(tempExePath);
            return new WpfRunner(paths, exePath);
        }

        public static string[] WPF_REFERENCES = new string[] {
            @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\presentationframework.dll",
            @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\windowsbase.dll",
            @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0\presentationcore.dll"
        };
    }
}
