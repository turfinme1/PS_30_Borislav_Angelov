using StudentInfoSystem.Enums;
using System.Collections.Generic;
using System.Linq;

namespace StudentInfoSystem
{
    public class StudentData
    {
        public List<Student>? TestStudents { get; private set; }

        public StudentData()
        {
            TestStudents = new List<Student>();

            TestStudents.Add(new Student()
            {
                FirstName = "Ivan",
                MiddleName = "Georgiev",
                LastName = "Ivanov",
                Speciality = "Computer and software engineering",
                Faculty = "FCST",
                Course = 3,
                FacultyNumber = "121219000",
                Group = 30,
                Degree = Degree.Професионално,
                Status = EducationStatus.Редовен,
                Stream = 9
            });
        }

        public bool IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student? result = context.Students.FirstOrDefault(s => s.FacultyNumber == facNum);
            return result != null;
        }
    }
}
