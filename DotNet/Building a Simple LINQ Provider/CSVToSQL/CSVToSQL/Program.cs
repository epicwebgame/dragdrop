using System;
using System.IO;

namespace CSVToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCourses();

            ReadTags();

            Console.ReadKey();
        }

        static void ReadCourses()
        {
            var coursesCSVFilePath = new FileInfo("..\\..\\CSV Files\\Courses.csv").FullName;

            using (var coursesCSVFile = new CSVFile(coursesCSVFilePath))
            {
                int i = 0;

                foreach (var row in coursesCSVFile.Rows)
                {
                    if (row.Index > 0)
                    {
                        ++i;
                        var course = row.ToCourse();
                        course.Save();
                    }
                }

                Console.WriteLine("({0} rows found)", i);
            }
        }

        static void ReadTags()
        {
            var tagsCSVFilePath = new FileInfo("..\\..\\CSV Files\\Tags.csv").FullName;

            using (var tagsCSVFile = new CSVFile(tagsCSVFilePath))
            {
                int i = 0;

                foreach (var row in tagsCSVFile.Rows)
                {
                    if (row.Index > 0)
                    {
                        ++i;
                        var tag = row.ToTag();
                        tag.Save();
                    }
                }

                Console.WriteLine("({0} rows found)", i);
            }
        }
    }
}