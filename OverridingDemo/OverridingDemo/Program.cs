using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingDemo { 

    public abstract class Parent
    {
        public abstract void Wish();
        //{
        //    Console.WriteLine("Hello from Parrent");
        //}
    }


    public class Children : Parent
    {
        public override void Wish()
        {
            Console.WriteLine("hello from child");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Parent obj = new Children();
            obj.Wish(); // Compile time polymorphism(early binding)
        }
    }
}
