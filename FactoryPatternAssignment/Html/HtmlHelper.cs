using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment.Html
{
    public static class HtmlHelper
    {
        public static string StyleForComponent(Component component)
        {
            return $"top: {component.Top}px; left: {component.Left}px; width: {component.Width}px; height: {component.Height}px;";
        }
    }
}
