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
    [System.STAThread]
    public static void Main(string[] args)
    {{
        var window = new MainWindow();
        window.Show();
        new App().Run();
    }}
}}

public class MainWindow : System.Windows.Window
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

        Width = 600;
        Height = 400;
        Title = ""Simple Window"";
        WindowStyle = System.Windows.WindowStyle.ToolWindow;
        
        var canvas = new System.Windows.Controls.Canvas();
        System.Windows.Controls.Label label;
        System.Windows.Controls.TextBox textBox;
        {initializationSrc}

        Content = canvas;

    }}
}}
";

            return WpfRunner.FromCode(new[] { src });
        }
    }
}
