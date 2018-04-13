using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    public class WpfLabelComponent : Component
    {
        public override string MakeSource()
        {
            return $@"label = new System.Windows.Controls.Label();
                      label.Content=""{Content}"";
                      System.Windows.Controls.Canvas.SetTop(label, {Top});
                      System.Windows.Controls.Canvas.SetLeft(label,{Left});
                      label.Width={Width};
                      label.Height={Height};
                      canvas.Children.Add(label);";
        }
    }
}
