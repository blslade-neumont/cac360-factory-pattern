using FactoryPatternAssignment.Html.Components;
using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment.Html
{
    public class HtmlLayoutBuilder : LayoutBuilder
    {
        public HtmlLayoutBuilder()
            : base()
        {
        }

        public override Component MakeComponent(string type)
        {
            return type == "Anchor"  ? (Component)(new HtmlAnchorComponent())
                 : type == "Button"  ? (Component)(new HtmlButtonComponent())
                 : type == "Label"   ? (Component)(new HtmlLabelComponent())
                 : type == "TextBox" ? (Component)(new HtmlTextBoxComponent())
                 : null;
        }

        public override IRunnable MakeRunnerFromComponents()
        {
            string HTML = GetHTMLFromComponents();
            return HtmlRunner.FromCode(HTML);
        }

        private string GetHTMLFromComponents()
        {
            string html = $"<!doctype html>" +
                          $"<html>" +
                          $"<head><title>Factory Pattern Output HTML Page! Yay!</title></head>" +
                          $"<body>";

            foreach (Component component in m_components)
            {
                html += component.MakeSource();
            }

            return html +
                   $"</body>" +
                   $"</html>";
        }
    }
}
