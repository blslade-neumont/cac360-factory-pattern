using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    public abstract class LayoutBuilder
    {
        protected Queue<Component> m_components = new Queue<Component>();

        protected Dictionary<string, Type> m_componentTypes = new Dictionary<string, Type>();

        public Component AddComponent(string type, string content, float top, float left, float width, float height)
        {
            Component c = MakeComponent(type);
            c.Content = content;
            c.Top = top;
            c.Left = left;
            c.Width = width;
            c.Height = height;
            m_components.Enqueue(c);
            return c;
        }

        public Component RemoveComponent()
        {
            return m_components.Dequeue();
        }

        public virtual string[] GetValidComponentTypes()
        {
            return this.m_componentTypes.Keys.ToArray();
        }

        public virtual Component MakeComponent(string type)
        {
            if (!this.m_componentTypes.ContainsKey(type)) throw new NotSupportedException($"Invalid component type: {type}");
            var compType = this.m_componentTypes[type];
            var comp = (Component)Activator.CreateInstance(compType);
            return comp;
        }
        
        public async Task Process()
        {
            IRunnable runner = MakeRunnerFromComponents();
            await runner.Run();
        }

        protected abstract IRunnable MakeRunnerFromComponents();
    }
}
