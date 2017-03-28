using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResp
{
    class PurchaseOrder
    {
        public string PONo { get; set; }
        public decimal POAmount { get; set; }

        public PurchaseOrder(decimal amount, string orderNo)
        {
            PONo = orderNo;
            POAmount = amount;


        }
    }
    abstract class Employe
    {
        protected Employe successor;
        private string name;

        public Employe(string n)
        {
            name = n;
        }

        public void SetSuccessor(Employe e)
        {
            successor = e;
        }
        public abstract void HandleRequest(PurchaseOrder po);
    }

    class SuperVisor : Employe
    {
        public SuperVisor(string n) : base(n)
        {
        }

        public override void HandleRequest(PurchaseOrder po)
        {
            if (po.POAmount > 2500)
            {
                Console.WriteLine("SuperVisor Handled");
            }
            else
            {
                successor?.HandleRequest(po);
            }
        }
    }
    class AssistantManager : Employe
    {
        public AssistantManager(string n) : base(n)
        {
        }

        public override void HandleRequest(PurchaseOrder po)
        {
            if (po.POAmount <= 2500 && po.POAmount > 1000)
            {
                Console.WriteLine("AssistantManager Handled");
            }
            else
            {
                successor?.HandleRequest(po);
            }
        }
    }
    class Manager : Employe
    {
        public Manager(string n) : base(n)
        {
        }

        public override void HandleRequest(PurchaseOrder po)
        {
            if (po.POAmount <= 1000)
            {
                Console.WriteLine("Manager Handled");
            }
            else
            {
                successor?.HandleRequest(po);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Supervisor = new SuperVisor("supervisor");
            var AssistantMgr = new AssistantManager("assistant manager");
            var Mgr = new Manager("Manager");
            Supervisor.SetSuccessor(AssistantMgr);
            AssistantMgr.SetSuccessor(Mgr);
            var po = new PurchaseOrder(9990, "1");
            Supervisor.HandleRequest(po);
            Console.ReadKey();
        }
    }
}
