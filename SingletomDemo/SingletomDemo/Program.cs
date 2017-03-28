using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletomDemo
{
    class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("Private Constructor Called");
        }
        //No Multithreading.. Bad idea.. Very Bad
        public static Singleton CreateSingleton()
        {
            if (_singleton == null)
            {
                Console.WriteLine("First Time Create Start..!!");
                _singleton = new Singleton();
                Console.WriteLine("First Time Create End..!!");
            }
            return _singleton;
        }

        private static Singleton _singleton;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton obj1, obj2;
            obj2 = Singleton.CreateSingleton();
            obj1 = Singleton.CreateSingleton();
            if (obj1 == obj2)
            {
                Console.WriteLine("equal");
            }
            Console.ReadKey();
        }
    }
}
