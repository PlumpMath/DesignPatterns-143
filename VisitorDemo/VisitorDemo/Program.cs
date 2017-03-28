using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VisitorDemo
{
    struct Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class  Circle
    {
        public Point CentrePoint { get; set; }
        public double Radius { get; set; }
        public Color FillColor { get; set; }
    }
    //Represent an operation to be performed on the elements of an object structure. 
    //Visitor lets you define a new operation without changing the classes of the elements on which it operates.
    //.NET 3.5 provides extension methods
    static class Visitor
    {
        public static double Area(this Circle cir)
        {
            return Math.PI*cir.Radius*cir.Radius;
        }

        public static void SetColor(this Circle cir, Color color)
        {
            cir.FillColor = color;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle cir = new Circle();
            cir.Radius = 5.0;
            cir.CentrePoint = new Point(0, 0);
            Console.WriteLine("Area of the circle is {0}", cir.Area());
            cir.SetColor(Color.Green);
            Console.ReadKey();
        }
    }
}
