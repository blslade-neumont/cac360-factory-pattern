using FactoryPatternAssignment.Command;
using LayoutBuilderLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryPatternAssignment.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Dictionary<string, LayoutBuilder> m_layoutBuilders = new Dictionary<string, LayoutBuilder>()
        {
            { "HtmlLayoutBuilder", new HtmlLayoutBuilder() },
            { "WpfLayoutBuilder", new WpfLayoutBuilder() }
        };

        private bool m_canRemoveComponent = false;

        public MainViewModel()
        {
            m_exportType = ExportTypeOptions.FirstOrDefault();
            PropertyChanged += MainViewModel_PropertyChanged;
            CreateComponentCommand = new DelegateCommand(OnCreateClick);
            RemoveComponentCommand = new DelegateCommand(OnRemoveClick, OnCanRemove);
            BuildAndRunCommand = new DelegateCommand(OnBuildAndRun);
            ResetState();
        }

        private bool OnCanRemove(object arg)
        {
            return m_canRemoveComponent;
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ExportType")
            {
                OnExportTypeChanged();
            }
        }

        private void OnExportTypeChanged()
        {
            ResetState();
        }

        private void ResetState()
        {
            Top = 0;
            Left = 0;
            Width = 0;
            Height = 0;
            Content = "";

            LayoutBuilder lb = m_layoutBuilders[ExportType];
            TypeOptions = lb.GetValidComponentTypes();
            ComponentType = TypeOptions.FirstOrDefault();

            Components.Clear();
            SetEmpty();
        }

        private float m_top;
        public float Top
        {
            get { return m_top; }
            set { SetProperty(ref m_top, value); }
        }

        private float m_left;
        public float Left
        {
            get { return m_left; }
            set { SetProperty(ref m_left, value); }
        }

        private float m_width;
        public float Width
        {
            get { return m_width; }
            set { SetProperty(ref m_width, value); }
        }

        private float m_height;
        public float Height
        {
            get { return m_height; }
            set { SetProperty(ref m_height, value); }
        }

        private string m_content;
        public string Content
        {
            get { return m_content; }
            set { SetProperty(ref m_content, value); }
        }

        private IEnumerable<string> m_typeOptions;
        public IEnumerable<string> TypeOptions
        {
            get { return m_typeOptions; }
            set { SetProperty(ref m_typeOptions, value); }
        }

        private string m_componentType;
        public string ComponentType
        {
            get { return m_componentType; }
            set { SetProperty(ref m_componentType, value); }
        }

        public IEnumerable<string> ExportTypeOptions => m_layoutBuilders.Keys;

        private string m_exportType;
        public string ExportType
        {
            get { return m_exportType; }
            set { SetProperty(ref m_exportType, value); }
        }

        public ObservableCollection<Component> Components { get; } = new ObservableCollection<Component>();

        public ICommand CreateComponentCommand { get; private set; }
        public ICommand RemoveComponentCommand { get; private set; }
        public ICommand BuildAndRunCommand { get; private set; }

        private void OnCreateClick(object obj)
        {
            Components.Add(m_layoutBuilders[ExportType].AddComponent(ComponentType, Content, Top, Left, Width, Height));
            if (Components.Count == 1) { SetNotEmpty(); }
        }

        private void OnRemoveClick(object obj)
        {
            Components.Remove(m_layoutBuilders[ExportType].RemoveComponent());
            if (Components.Count == 0) { SetEmpty(); }
        }
        
        private void SetEmpty()
        {
            m_canRemoveComponent = false;
            ((DelegateCommand)RemoveComponentCommand).RaiseCanExecuteChanged();
        }

        private void SetNotEmpty()
        {
            m_canRemoveComponent = true;
            ((DelegateCommand)RemoveComponentCommand).RaiseCanExecuteChanged();
        }

        private async void OnBuildAndRun(object obj)
        {
            await m_layoutBuilders[ExportType].Process();
        }
    }
}
