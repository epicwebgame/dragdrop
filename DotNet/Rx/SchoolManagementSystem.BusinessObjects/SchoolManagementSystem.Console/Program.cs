using SchoolManagementSystem.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SchoolManagementSystem.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var schools = new List<School>();

            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    var school = new School(string.Format($"School {++i}"));
                    school.FillWithStudents(100);
                    schools.Add(school);
                });
            }

            Thread.Sleep(3000);

            foreach (var school in schools)
            {
                Console.WriteLine($"{school.Name} has {school.NumberOfStudents} students");

                foreach (var student in school.Take(10))
                    Console.WriteLine(student);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
