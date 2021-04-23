using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }

        public Student()
        {

        }
        public Student(string f, string l, string g)
        {
            this.FirstName = f;
            this.LastName = l;
            this.Grade = g;
        }
    }
}
