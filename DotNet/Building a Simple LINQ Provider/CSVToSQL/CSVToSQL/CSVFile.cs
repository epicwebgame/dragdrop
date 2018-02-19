using CSVToSQL.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSVToSQL
{
    public sealed class CSVFile : IDisposable
    {
        private const string Quote = "\"";
        private const string EscapedQuote = "\"\"";

        private static char[] CharactersThatMustBeQuoted = { ',', '"', '\n' };
        private static Regex CsvSplitterRegEx = new Regex(@",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");
        private static Regex RunOnLineRegEx = new Regex(@"^[^""]*(?:""[^""]*""[^""]*)*""[^""]*$");

        private string _fileName = null;
        private long _rowIndex = 0;
        private TextReader _reader;

        public class Row : IEnumerable<string>
        {
            private string[] _values = null;
            private long _rowIndex = -1;
            private string _fileName = null;

            public Row(string fileName, string[] values, long rowIndex)
            {
                _fileName = fileName;

                _values = values;

                _rowIndex = rowIndex;
            }

            public IEnumerator<string> GetEnumerator()
            {
                return _values.AsEnumerable<string>().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public string File
            {
                get
                {
                    return _fileName;
                }
            }

            public long Index
            {
                get
                {
                    return _rowIndex;
                }
            }

            public string this[int columnIndex]
            {
                get
                {
                    return _values[columnIndex];
                }
            }

            public Course ToCourse()
            {
                var course = new Course();

                try
                {
                    course.Id = this[(int)CourseDataCSVColumnIndices.Id];
                    course.Title = this[(int)CourseDataCSVColumnIndices.Title];
                    course.DurationInSeconds = int.Parse(this[(int)CourseDataCSVColumnIndices.DurationInSeconds]);
                    course.ReleaseDate = DateTime.Parse(this[(int)CourseDataCSVColumnIndices.ReleaseDate], CultureInfo.CurrentCulture.DateTimeFormat);
                    course.Description = this[(int)CourseDataCSVColumnIndices.Description];
                    course.AssessmentStatus = this[(int)CourseDataCSVColumnIndices.AssessmentStatus];
                    course.IsCourseRetired = this[(int)CourseDataCSVColumnIndices.IsCourseRetired].ToBoolean();
                }
                catch(Exception e)
                {
                    throw new FormatException(
                        string.Format("The CSV file does not appear to contain course information. File: {0}, Error at data row number: {1}.",
                        this.File, this.Index + 1), e);
                }

                return course;
            }

            public Tag ToTag()
            {
                var tag = new Tag();

                try
                {
                    tag.Id = this[(int)TagDataCSVColumnIndices.Id];
                    tag.DisplayName = this[(int)TagDataCSVColumnIndices.DisplayName];
                    tag.Description = this[(int)TagDataCSVColumnIndices.Description];
                }
                catch (Exception e)
                {
                    throw new FormatException(
                        string.Format("The CSV file does not appear to contain tag information. File: {0}, Error at data row number: {1}.",
                        this.File, this.Index + 1), e);
                }

                return tag;
            }
        }

        public CSVFile(string fileName)
        {
            _fileName = new FileInfo(fileName).FullName;

            _reader = new StreamReader(new FileStream(_fileName, FileMode.Open, FileAccess.Read));
        }

        public IEnumerable<CSVFile.Row> Rows
        {
            get
            {
                _rowIndex = -1; string line; string nextLine;

                while ((line = _reader.ReadLine()).IsNotNull())
                {
                    while (RunOnLineRegEx.IsMatch(line) && (nextLine = _reader.ReadLine()).IsNotNull())
                        line = line.Plus("\n", nextLine);

                    _rowIndex++;
                    string[] values = CsvSplitterRegEx.Split(line);

                    for (int i = 0; i < values.Length; i++)
                        values[i] = Unescape(values[i]);

                    yield return new CSVFile.Row(_fileName, values, _rowIndex);
                }

                _reader.Close();
            }
        }

        public void Dispose()
        {
            if (_reader.IsNotNull()) _reader.Dispose();
        }

        public static string Escape(string s)
        {
            if (s.Contains(Quote))
                s = s.Replace(Quote, EscapedQuote);

            if (s.IndexOfAny(CharactersThatMustBeQuoted) > -1)
                s = Quote.Plus(s).Plus(Quote);

            return s;
        }

        public static string Unescape(string s)
        {
            if (s.StartsWith(Quote) && s.EndsWith(Quote))
            {
                s = s.Substring(1, s.Length - 2);

                if (s.Contains(EscapedQuote))
                    s = s.Replace(EscapedQuote, Quote);
            }

            return s;
        }
    }
}