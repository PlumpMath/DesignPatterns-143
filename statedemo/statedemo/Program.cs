using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statedemo
{
    abstract class State
    {
        public Computer Computer { get; set; }
        public decimal MemoryUse { get; set; }
        public abstract void AllocateMemory(decimal mem);
        public abstract void DeallocateMemory(decimal mem);
    }

    class NormalState : State
    {
        public NormalState(State state):this(state.MemoryUse, state.Computer) { }

        public NormalState(decimal memuse, Computer comp)
        {
            this.MemoryUse = memuse;
            this.Computer = comp;
        }

        private void StateChangeCheck()
        {
            if (MemoryUse > 50 && MemoryUse <= 100)
            {
                Computer.State = new BusyState(this);
            }
            if (MemoryUse > 100)
            {
                Computer.State = new SwapState(this);
            }
        }
        public override void AllocateMemory(decimal mem)
        {
            MemoryUse += mem;
            StateChangeCheck();
        }

        public override void DeallocateMemory(decimal mem)
        {
            MemoryUse -= mem;
            StateChangeCheck();
        }
    }
    class BusyState : State
    {
        public BusyState(State state) : this(state.MemoryUse, state.Computer) { }

        public BusyState(decimal memuse, Computer comp)
        {
            this.MemoryUse = memuse;
            this.Computer = comp;
        }

        private void StateChangeCheck()
        {
            if (MemoryUse <= 50 )
            {
                Computer.State = new NormalState(this);
            }
            if (MemoryUse > 100)
            {
                Computer.State = new SwapState(this);
            }
        }
        public override void AllocateMemory(decimal mem)
        {
            MemoryUse += mem;
            StateChangeCheck();
        }

        public override void DeallocateMemory(decimal mem)
        {
            MemoryUse -= mem;
            StateChangeCheck();
        }
    }
    class SwapState : State
    {
        public SwapState(State state) : this(state.MemoryUse, state.Computer) { }

        public SwapState(decimal memuse, Computer comp)
        {
            this.MemoryUse = memuse;
            this.Computer = comp;
        }

        private void StateChangeCheck()
        {
            if (MemoryUse > 50 && MemoryUse <= 100)
            {
                Console.WriteLine("Changing state from swap state -> Busy State");
                Computer.State = new BusyState(this);
            }
            if (MemoryUse <= 50)
            {
                Computer.State = new NormalState(this);
            }
        }
        public override void AllocateMemory(decimal mem)
        {
            MemoryUse += mem;
            StateChangeCheck();
        }

        public override void DeallocateMemory(decimal mem)
        {
            MemoryUse -= mem;
            StateChangeCheck();
        }
    }

    class Computer
    {
        public State State { get; set; }

        public decimal MemoryUse
        {
            get { return State.MemoryUse; }
        }

        public void Allocate(decimal mem)
        {
            State.AllocateMemory(mem);
            Console.WriteLine("Current Memory usage: {0}", this.MemoryUse);
            Console.WriteLine("Status: {0}", this.State.GetType().Name);
        }
        public void Deallocate(decimal mem)
        {
            State.DeallocateMemory(mem);
            Console.WriteLine("Current Memory usage: {0}", this.MemoryUse);
            Console.WriteLine("Status: {0}", this.State.GetType().Name);
        }
        public Computer()
        {
            State = new NormalState(0.0M, this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Allocate(20);
            comp.Allocate(10);
            comp.Allocate(40);
            comp.Allocate(50);
            comp.Deallocate(60);
            Console.ReadKey();
        }
    }
}
