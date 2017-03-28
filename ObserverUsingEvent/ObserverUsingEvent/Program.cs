using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverUsingEvent
{
    public delegate void Change(double amt);

    public class Stock //publisher
    {
        public event Change StockChange;
        private double amt;

        public Stock(double amt)
        {
            this.amt = amt;
        }

        public double Amt
        {
            get { return amt; }
            set
            {
                amt = value;
                StockChange(amt);
            }
        }
    }

    //Subject
    public class Investor
    {
        private string name;
        public Investor(Stock s, string name)
        {
            s.StockChange += s_StockChanged;
            this.name = name;
        }

        void s_StockChanged(double amt)
        {
            Console.WriteLine("Stock Price of {1} changed to {0}", amt, name);
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stock citrix = new Stock(100);
            Investor me = new Investor(citrix,"mahesh");
            citrix.Amt = 110;
            citrix.Amt = 120;
            citrix.Amt = 130;
            Investor someInvestor = new Investor(citrix, "Akasa Ramannaa");
            citrix.Amt = 80;
            Console.ReadKey();
        }
    }
}
