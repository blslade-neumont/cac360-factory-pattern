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
            var runner = HtmlRunner.FromHtml($"<!doctype html>" +
                $"<html>" +
                $"<head><title>My Title</title></head>" +
                $"<body>" +
                $"  Hello, World!" +
                $"</body>" +
                $"</html>");

            runner.Run();
        }
    }
}
