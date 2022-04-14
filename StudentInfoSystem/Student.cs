using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string firstName;
        public string secondName;
        public string lastName;
        public string faculty;
        public string speciality;
        public string degree;
        public string status;
        public string facultyNumber;
        public int course;
        public int flow;
        public int group;

        public Student(string firstName, string secondName, string lastName, string faculty, string speciality,
            string degree, string status, string facultyNumber, int course, int flow, int group)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.speciality = speciality;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.flow = flow;
            this.group = group;
        }
    }
}
