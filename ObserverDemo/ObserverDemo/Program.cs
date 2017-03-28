using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemo
{
    public abstract class Stock
    {
        protected string symbol;
        protected double price;
        private List<Investor> InverstorList = new List<Investor>();

        protected Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(Investor investor)
        {
            Console.WriteLine("Attaching {0}...", investor.Name);
            InverstorList.Add(investor);
        }

        public void Detach(Investor investor)
        {
            Console.WriteLine("Detaching {0}...", investor.Name);
            InverstorList.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in InverstorList)
            {
                Console.WriteLine("Notifying Investor:{0}", investor.Name);
                investor.Update(this);
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                Notify();
            }
        }

        public string Symbol
        {
            get {  return symbol; }
            set { symbol = value; }
        }
    }

    public class IBM : Stock
    {
        public IBM(string symbol, double price) : base(symbol, price)
        {
            
        }
    }

    public class MicroSoft : Stock
    {
        public MicroSoft(string symbol, double price) : base(symbol, price)
        {

        }
    }

    interface IInvestor
    {
        void Update(Stock stock);
    }

    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;

        public Investor(string name)
        {
            this.name = name;
        }   
        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s price change {2}",name,stock.Symbol, stock.Price);
        }

        public string Name
        {
            get { return name; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Investor a = new Investor("Sorros");
            Investor b = new Investor("Backshire");
            IBM ibm = new IBM("IBM", 70.56);
            ibm.Attach(a);
            ibm.Attach(b);
            ibm.Price = 89.00;
            ibm.Price = 98.88;
            Console.ReadKey();
        }
    }
}
