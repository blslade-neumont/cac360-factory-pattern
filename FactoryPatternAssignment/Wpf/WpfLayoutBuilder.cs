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
        }

        public override Component MakeComponent(string type)
        {
            return type == "Label" ? (Component)(new WpfLabelComponent())
                 : type == "TextBox" ? (Component)(new WpfTextBoxComponent())
                 : null;
        }

        public override IRunnable MakeRunnerFromComponents()
        {
            throw new NotImplementedException();
        }
    }
}
