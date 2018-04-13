using FactoryPatternAssignment.Html.Components;
using FactoryPatternAssignment.Wpf;
using FactoryPatternAssignment.Wpf.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    public class WpfLayoutBuilder : LayoutBuilder
    {
        public WpfLayoutBuilder()
            : base()
        {
            this.m_componentTypes["Label"] = typeof(WpfLabelComponent);
            this.m_componentTypes["TextBox"] = typeof(WpfTextBoxComponent);
        }
        
        protected override IRunnable MakeRunnerFromComponents()
        {
            throw new NotImplementedException();
        }
    }
}
