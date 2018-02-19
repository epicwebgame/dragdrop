using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolManagementSystem.BusinessObjects
{
    public class School: IEnumerable<Student>
    {
        private List<Student> _students;

        public static event Action<NewStudentAdmittedEventArgs> StudentAdmitted;

        public string Name { get; set; }
        
        public School(string name)
        {
            Name = name;
            _students = new List<Student>();
        }

        public void AdmitStudent(Student student)
        {
            if (!_students.Contains(student))
            {
                _students.Add(student);

                if (StudentAdmitted != null)
                    StudentAdmitted(new NewStudentAdmittedEventArgs(this, student, DateTime.Now));
            }
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int NumberOfStudents
        {
            get
            {
                return _students.Count;
            }
        }
    }
}
