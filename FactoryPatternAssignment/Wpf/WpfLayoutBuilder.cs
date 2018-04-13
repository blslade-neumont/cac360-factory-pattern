using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
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
            StringBuilder sb = new StringBuilder();
            foreach (var comp in this.m_components)
            {
                sb.Append(comp.MakeSource());
            }
            string initializationSrc = sb.ToString();

            string src = $@"
public class App : System.Windows.Application
{{
    public static void Main(string[] args)
    {{
        new App().Run();
    }}
    
    protected override void OnStartup(System.Windows.StartupEventArgs e)
    {{
        base.OnStartup(e);
        new MainWindow().Show();
    }}
}}

public class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
{{
    public MainWindow()
        : base()
    {{
        InitializeComponent();
    }}
    
    private bool _contentLoaded;
    
    public void InitializeComponent()
    {{
        if (_contentLoaded) return;
        _contentLoaded = true;
        
        {initializationSrc}
    }}
    
    void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {{
        this._contentLoaded = true;
    }}
}}
";

            return WpfRunner.FromCode(new[] { src });
        }
    }
}
