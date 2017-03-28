using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDemo
{
    public class WcfSvc
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public string Hello()
        {
            return "Hello wrold";
        }
    }

    public class WcfSvcProxy
    {
        WcfSvc wcfSvc = new WcfSvc();
        public int Add(int x, int y)
        {
            return wcfSvc.Add(x,y);
        }

        public string Hello()
        {
            return wcfSvc.Hello();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            WcfSvcProxy wcfSvcProxy = new WcfSvcProxy();
            wcfSvcProxy.Add(4, 3);
            wcfSvcProxy.Hello();
        }
    }
}
