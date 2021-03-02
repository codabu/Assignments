using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignments.Models
{
    public class ViewModel
    {
        public List<Student> studentList { get; set; }
        public int accessLevel { get; set; }

        Student student1 = new Student("Corry", "Burton", "A");
        Student student2 = new Student("Danielle", "Mathers", "B");
        Student student3 = new Student("Joey", "Tremon", "D");


        public ViewModel()
        {
            studentList = new List<Student>();
            studentList.Add(student1);
            studentList.Add(student2);
            studentList.Add(student3);
        }

        public ViewModel(int id)
        {
            accessLevel = id;
            studentList = new List<Student>();
            studentList.Add(student1);
            studentList.Add(student2);
            studentList.Add(student3);
        }
    }
}
