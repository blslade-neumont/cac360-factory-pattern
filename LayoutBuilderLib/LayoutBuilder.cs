using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    public abstract class LayoutBuilder
    {
        protected Stack<Component> m_components = new Stack<Component>();

        public void AddComponent(string type, string content, float top, float left, float width, float height)
        {
            Component c = MakeComponent(type);
            c.Content = content;
            c.Top = top;
            c.Left = left;
            c.Width = width;
            c.Height = height;
            m_components.Push(c);
        }

        public void RemoveComponent()
        {
            m_components.Pop();
        }

        public abstract Component MakeComponent(string type);

        public async Task Process()
        {
            IRunnable runner = MakeRunnerFromComponents();
            await runner.Run();
        }

        public abstract IRunnable MakeRunnerFromComponents();
    }
}
