using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternDemo
{
    class Program
    {
        abstract class DrawingElement
        {
            protected string _name;

            protected DrawingElement(string name)
            {
                _name = name;
            }

            public abstract void Add(DrawingElement d);
            public abstract void Remove(DrawingElement d);
            public abstract void Display(int indent);
        }

        class PrimitiveElement : DrawingElement
        {
            public PrimitiveElement(string name) : base(name)
            {
            }

            public override void Add(DrawingElement d)
            {
                Console.WriteLine("Primitive Add. Nothing happening");
            }

            public override void Remove(DrawingElement d)
            {
                Console.WriteLine("Primitive Remove");
            }

            public override void Display(int indent)
            {
                Console.WriteLine(new string('-', indent)+"+ " + _name);
            }
        }

        //composite class
        class CompositeElement : DrawingElement
        {
            private List<DrawingElement> elements = new List<DrawingElement>();
            public CompositeElement(string name) : base(name)
            {
            }

            public override void Add(DrawingElement d)
            {
                elements.Add(d);
            }

            public override void Remove(DrawingElement d)
            {
                elements.Remove(d);
            }

            public override void Display(int indent)
            {
                Console.WriteLine(new string('-', indent) + "+ " + _name);
                foreach (var drawingElement in elements)
                {
                    drawingElement.Display(indent + 2);
                }    
            }
        }

        static void Main(string[] args)
        {
            var root = new CompositeElement("root");
            root.Add(new PrimitiveElement("leaf"));
            var circleComposite = new CompositeElement("circle");
            root.Add(circleComposite);
            root.Add(new PrimitiveElement("square"));
            circleComposite.Add(new PrimitiveElement("red circle"));
            circleComposite.Add(new PrimitiveElement("Blue  circle"));
            circleComposite.Add(new PrimitiveElement("Green circle"));
            root.Display(4);
            Console.ReadKey();
        }
    }
}
