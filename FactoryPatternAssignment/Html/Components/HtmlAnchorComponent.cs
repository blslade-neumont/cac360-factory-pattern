using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment.Html.Components
{
    public class HtmlAnchorComponent : Component
    {
        public override string MakeSource()
        {
            return $"<a href=\"{Content}\" style=\"{HtmlHelper.StyleForComponent(this)}\">{Content}</a>";
        }
    }
}
