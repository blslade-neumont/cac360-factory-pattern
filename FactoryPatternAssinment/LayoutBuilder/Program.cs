using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    public class Program
    {
        /// <summary>
        /// Note: this entry point is for testing the HtmlRunner and WpfRunner functionality
        /// </summary>
        /// <param name="args">The command-line arguments passed to the test entry point</param>
        public static void Main(string[] args)
        {
            //RunHtml().Wait();
            RunWpf().Wait();
        }

        private static async Task RunHtml()
        {
            var runner = HtmlRunner.FromCode($"<!doctype html>" +
                $"<html>" +
                $"<head><title>My Title</title></head>" +
                $"<body>" +
                $"  Hello, World!" +
                $"</body>" +
                $"</html>");

            await runner.Run();
        }

        private static async Task RunWpf()
        {
            var runner = WpfRunner.FromCode($"using System;" +
                "public class Program" +
                "{" +
                "  public static void Main(string[] args)" +
                "  {" +
                "    Console.WriteLine(\"Hello, World!\");" +
                "    Console.ReadKey();" +
                "  }" +
                "}");

            await runner.Run();
        }
    }
}
