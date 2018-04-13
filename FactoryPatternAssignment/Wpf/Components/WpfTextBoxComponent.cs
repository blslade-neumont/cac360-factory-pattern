using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    public class WpfTextBoxComponent : Component
    {
        public override string MakeSource()
        {
            return $@"textBox = new System.Windows.Controls.TextBox();
                      textBox.Text=""{Content}"";
                      System.Windows.Controls.Canvas.SetTop(textBox, {Top});
                      System.Windows.Controls.Canvas.SetLeft(textBox,{Left});
                      textBox.Width={Width};
                      textBox.Height={Height};
                      canvas.Children.Add(textBox);";
        }
    }
}
