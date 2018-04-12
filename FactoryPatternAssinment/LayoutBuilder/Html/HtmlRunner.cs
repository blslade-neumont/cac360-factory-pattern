using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    internal class HtmlRunner
    {
        public HtmlRunner(string path)
        {
            this.path = path;
        }

        public static HtmlRunner FromCode(string html)
        {
            var tempPath = Path.GetTempFileName();
            var path = tempPath.Replace(".tmp", ".html");
            File.Move(tempPath, path);
            File.WriteAllText(path, html, Encoding.UTF8);
            return new HtmlRunner(path);
        }

        private string path;

        public async Task Run()
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = this.path;
            proc.Start();

            await proc.WaitForExitAsync();
        }
    }
}
