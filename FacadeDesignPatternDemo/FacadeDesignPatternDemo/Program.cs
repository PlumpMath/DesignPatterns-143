using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    class Candidate
    {
        public Candidate(string name, string postApplied)
        {
            Name = name;
            PostApplied = postApplied;
        }
        public string Name { get; set; }
        public string PostApplied { get; set; }
    }

    class Education
    {
        private decimal marks;

        public Education(decimal marks)
        {
            this.marks = marks;
        }

        public bool IsEligible()
        {
            return marks > 90;
        }
    }
    
    class WrittenTest
    {
        private decimal marks;

        public WrittenTest(decimal marks)
        {
            this.marks = marks;
        }

        public bool IsEligible()
        {
            return marks > 60;
        }
    }
    class Interview
    {
        private decimal points;

        public Interview(decimal points)
        {
            this.points = points;
        }

        public bool IsEligible()
        {
            return points > 7;
        }
    }
    //Facade Class
    class CandidateEligible
    {
        private Candidate candidate;
        private Education education;
        private WrittenTest writtenTest;
        private Interview interview;
        public CandidateEligible(string name, string post, decimal eduMarks, decimal testMarks, decimal interviewPoints)
        {
            candidate = new Candidate(name,post);   
            education = new Education(eduMarks);
            writtenTest = new WrittenTest(testMarks);
            interview = new Interview(interviewPoints);
        }

        public bool IsEligible()
        {
            return education.IsEligible() && writtenTest.IsEligible() && interview.IsEligible();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CandidateEligible can = new CandidateEligible("random", "randompost",0,0,0);
            if (can.IsEligible())
            {
                Console.WriteLine("Eligible..!!");
            }
            else
            {
                Console.WriteLine("Reject..!!");
            }
            Console.ReadKey();
        }
    }
}
