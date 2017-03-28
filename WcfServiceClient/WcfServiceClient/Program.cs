using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient.ServiceReference1;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfSvcClient svc = new WcfSvcClient("WSHttpBinding_IWcfSvc");
            Console.WriteLine(svc.Add(4,3));
            Console.WriteLine(svc.Hello());
            Console.ReadLine();
        }
    }
}
