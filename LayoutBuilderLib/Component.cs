using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutBuilderLib
{
    public abstract class Component
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Content { get; set; }

        public abstract string MakeSource();

        public override string ToString()
        {
            return $"ComponentType: {GetType().Name}, Top: {Top}, Left: {Left}, Width: {Width}, Height: {Height}, Content: {Content}";
        }
    }
}
