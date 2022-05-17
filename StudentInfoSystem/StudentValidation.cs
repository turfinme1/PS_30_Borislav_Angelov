using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student? GetStudentDataByUser(User user)
        {
            if (user.FakNum == null)
            {
                return null;
            }

            return new Student
            {
                FacultyNumber = user.FakNum
            };
        }
    }
}
