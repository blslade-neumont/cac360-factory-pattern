using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    public abstract class LayoutBuilder
    {
        Stack<Component> components = new Stack<Component>();

        public void AddComponent(string type, string content, float top, float left, float width, float height)
        {
            Component c = MakeComponent(type);
            c.Content = content;
            c.Top = top;
            c.Left = left;
            c.Width = width;
            c.Height = height;
            components.Push(c);
        }

        public void RemoveComponent()
        {
            components.Pop();
        }

        public abstract Component MakeComponent(string type);

        // Brandon Stuff Method, Name to be changed as well as possibly splitting it?

        public abstract void Process();
    }
}
