using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WebServiceLibrary
{
    [ServiceContract]
    interface IWcfSvc
    {
        [OperationContract]
        string Hello();
        [OperationContract]
        int Add(int x, int y);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfSvc : IWcfSvc
    {
        public WcfSvc()
        {
            Console.WriteLine("Service object created..!!!");
        }
        public string Hello()
        {
            return "hello world";
        }

        public int Add(int x, int y)
        {
            return x+y;
        }
    }
}
