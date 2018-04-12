using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace LayoutBuilderLib
{
    public class Program
    {
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
