using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern
{
    abstract class MessageStrategy
    {
        public abstract void SendMessage(string msg); //Interface used by context and all algorithnms
    }

    class SMSMessage : MessageStrategy
    {
        public override void SendMessage(string msg)
        {
            Console.WriteLine("SMS sent");   
        }
    }

    class EmailMessage : MessageStrategy
    {
        public override void SendMessage(string msg)
        {
            Console.WriteLine("Email Sent..!!!");
        }
    }
    class WhatsAppMessage : MessageStrategy
    {
        public override void SendMessage(string msg)
        {
            Console.WriteLine("Whatsapp Message Sent..!!!!");
        }
    }

    class Context
    {
        private MessageStrategy messageStrategy; //reference to strategy object

        public void SetMessageStrategy(MessageStrategy messageStrategy)
        {
            this.messageStrategy = messageStrategy; //configure with concrete strategy
        }

        public void SendMessage(string msg)
        {
            messageStrategy.SendMessage(msg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Context ct = new Context();
            var sms = new SMSMessage();
            var whatsapp = new WhatsAppMessage();
            var email = new EmailMessage();
            ct.SetMessageStrategy(sms);
            ct.SendMessage("HI");
            ct.SetMessageStrategy(whatsapp);
            ct.SendMessage("HI");
            ct.SetMessageStrategy(email);
            ct.SendMessage("HI");
            Console.ReadKey();
        }
    }
}
