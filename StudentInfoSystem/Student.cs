using StudentInfoSystem.Enums;
using System;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public byte[]? Photo { get; set; }

        public string? Faculty { get; set; }

        public string? Speciality { get; set; }

        public Degree Degree { get; set; }

        public EducationStatus Status { get; set; }

        public string FacultyNumber { get; set; }

        public int Course { get; set; }

        public int Stream { get; set; }

        public int Group { get; set; }
    }
}
