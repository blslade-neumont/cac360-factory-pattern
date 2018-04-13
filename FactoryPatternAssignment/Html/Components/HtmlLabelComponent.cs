using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    public class HtmlLabelComponent : Component
    {
        public override string MakeSource()
        {
            return $"<button style=\"{HtmlHelper.StyleForComponent(this)}\">{Content}</button>";
        }
    }
}
