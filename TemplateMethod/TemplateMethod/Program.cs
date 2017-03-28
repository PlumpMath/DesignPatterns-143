using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    abstract class Shape
    {
        public abstract void Draw();
        public abstract void Area();

        public void Erase()
        {
            Console.WriteLine("Erasing..");
        }

        //Template method
        public void Execute()
        {
            Draw();
            Area();
            Erase();
        }
    }
    class Circle:Shape
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }

        public override void Area()
        {
            Console.WriteLine("Area:{0}", Math.PI * radius* radius);
        }
    }

    class Rectangle : Shape
    {
        private int length;
        private int breadth;
        public Rectangle(int length, int breadth)
        {
            this.length = length;
            this.breadth = breadth;
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override void Area()
        {
            Console.WriteLine("Area:{0}",  length * breadth);
        }
    }

    class Square : Shape
    {
        private int length;
        public Square(int length)
        {
            this.length = length;
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing Square");
        }

        public override void Area()
        {
            Console.WriteLine("Area:{0}", length * length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(4,3);
            rect.Execute();
            var square = new Square(5);
            square.Execute();
            var circle = new Circle(7);
            circle.Execute();
            Console.ReadKey();
        }
    }
}
