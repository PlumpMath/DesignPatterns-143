using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodDemo
{
    class Example
    {
        public void Random1() { }
    }

    static class ClassWithExtensionMethod //class name is irrelevant
    {
        //static class with static methods
        //Extension method is a kind of static method but can be called as an instance method on the extended object.
        public static void Random2(this Example ex) { }
    }
    //Sealed class cannot be used as base class. Run time optimization can make sealed classes faster.
    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            ex.Random1();
            ex.Random2(); //Extension Method
        }
    }
}
