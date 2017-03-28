using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebServiceLibrary;

namespace WcfSvcConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = new ServiceHost(typeof(WebServiceLibrary.WcfSvc));
            svcHost.Open();
            Console.WriteLine("WCF Service is Ready...");
            Console.WriteLine("Press Enter to stop");
            Console.ReadLine();
            svcHost.Close();
        }
    }
}
