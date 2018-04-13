using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    public class HtmlLayoutBuilder : LayoutBuilder
    {
        public HtmlLayoutBuilder()
            : base()
        {
            this.m_componentTypes["Anchor"] = typeof(HtmlAnchorComponent);
            this.m_componentTypes["Button"] = typeof(HtmlButtonComponent);
            this.m_componentTypes["Label"] = typeof(HtmlLabelComponent);
            this.m_componentTypes["TextBox"] = typeof(HtmlTextBoxComponent);
        }

        protected override IRunnable MakeRunnerFromComponents()
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
