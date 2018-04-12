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
            throw new NotImplementedException();
        }

        public override IRunnable MakeRunnerFromComponents()
        {
            throw new NotImplementedException();
            //string[] WPF = GetWPFFromComponents();
            //return new WpfRunner(???);
        }
    }
}
