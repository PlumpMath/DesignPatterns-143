using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDBDemo
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
    }

    class DBTransaction
    {
        public int Count { get; set; }
        List<Employee> empList = new List<Employee>();

        public void Insert(Employee emp)
        {
            empList.Add(emp);
            Count++;
        }

        public void Update(int eid, Employee emp)
        {
            var emp2edit = (from e in empList where e.EmpId == eid select e).First();
            emp2edit.EmpName = emp.EmpName;
            emp2edit.EmpSalary = emp.EmpSalary;
        }

        public void Delete(int eid)
        {
            var emp2del = (from e in empList where e.EmpId == eid select e).First();
            empList.Remove(emp2del);
            Count--;
        }

        public void PrintRecords()
        {
            foreach (var emp in empList)
            {
                Console.WriteLine("Id:{0}, Nmae:{1}, Salary:{2}",emp.EmpId, emp.EmpName, emp.EmpSalary);
            }
        }
    }

    interface ICommand
    {
        void Insert(Employee emp);
        void Update(int eid, Employee emp);
        void Delete(int eid);
        void BeginTransaction();
        void Commit();
        void Rollback();


    }

    class DBCommand : ICommand
    {
        private DBTransaction dbTransaction;
        private bool transactionInProgress;

        public DBCommand(DBTransaction dbTransaction)
        {
            this.dbTransaction = dbTransaction;
        }
        public void Insert(Employee emp)
        {
            dbTransaction.Insert(emp);
        }

        public void Update(int eid, Employee emp)
        {
            dbTransaction.Update(eid,emp);
        }

        public void Delete(int eid)
        {
            dbTransaction.Delete(eid);
        }

        public void BeginTransaction()
        {
            transactionInProgress = true;
        }

        public void Commit()
        {
            Console.WriteLine("Transaction Committed");
        }

        public void Rollback()
        {
            ;
        }
    }

    class User
    {
        private DBTransaction dbTransaction = new DBTransaction();
        private List<ICommand> commands = new List<ICommand>();

        public void Rollback()
        {
            for (int i = 0; i < dbTransaction.Count; i++)
            {
                var command = commands[i] as DBCommand;
                command.Rollback();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
