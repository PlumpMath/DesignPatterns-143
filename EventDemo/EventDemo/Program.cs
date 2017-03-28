using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    delegate void MyDel(string s);

    class MyButton
    {
        public event MyDel Click;

        public void SimulateClick(string s)
        {
            Click?.Invoke(s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
               
            MyButton btn1 = new MyButton();
            btn1.Click += Btn1_Click; //attach an event handler
            btn1.Click += Btn1_Click1; //attach one more event handler
            btn1.SimulateClick("hi");
            btn1.Click -= Btn1_Click;
            btn1.SimulateClick("Hello");
            Console.ReadKey();
        }

        private static void Btn1_Click1(string s)
        {
            Console.WriteLine("Btn1 click1 was clicked with message {0}", s);
        }

        private static void Btn1_Click(string s)
        {
            Console.WriteLine("Btn1 was clicked with message {0}", s);
        }
    }
}
