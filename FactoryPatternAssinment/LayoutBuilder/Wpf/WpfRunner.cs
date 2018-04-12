using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    internal class WpfRunner
    {
        public WpfRunner(IEnumerable<string> paths, string exePath)
        {
            this.paths = paths.ToArray();
            this.exePath = exePath;
        }

        public static WpfRunner FromCode(params string[] compilationUnits)
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

        private string[] paths;
        private string exePath;

        private string GetCSCPath()
        {
            var frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
            var cscPath = Path.Combine(frameworkPath, "csc.exe");
            return cscPath;
        }

        private async Task Build()
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = this.GetCSCPath();
            proc.StartInfo.Arguments = $@"-optimize -out:""{exePath}"" {string.Join(" ", this.paths.Select(path => "\"" + path + "\""))}";
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            
            await proc.WaitForExitAsync();
        }

        public async Task Run()
        {
            await Build();

            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = this.exePath;
            proc.Start();

            await proc.WaitForExitAsync();
        }
    }
}
