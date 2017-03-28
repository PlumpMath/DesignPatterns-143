using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Arithmetic
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }

    delegate int MyDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mainthread is {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            Arithmetic arith = new Arithmetic();
            int result;
            MyDel delObj = arith.Add;
            result = delObj(4, 2);
            delObj = arith.Divide;
            result = delObj(6, 2);
            var iasyncCallback = new AsyncCallback(SomeCallBack);
            var asyncresult = delObj.BeginInvoke(4, 5, iasyncCallback, delObj );

        }
        static void SomeCallBack(IAsyncResult result)
        {
            MyDel delObj = (MyDel) result.AsyncState;
            int result1 = delObj.EndInvoke(result);
            Console.WriteLine("result is {0}", result1);
        }
    }
    
}
