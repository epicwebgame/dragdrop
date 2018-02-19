using System;

namespace SchoolManagementSystem.BusinessObjects
{
    public class NewStudentAdmittedEventArgs
    {
        public NewStudentAdmittedEventArgs(School school, Student student, DateTime when)
        {
            School = school;
            Student = student;
            When = when;
        }

        public School School { get; }
        public Student Student { get; }
        public DateTime When { get; }
    }
}