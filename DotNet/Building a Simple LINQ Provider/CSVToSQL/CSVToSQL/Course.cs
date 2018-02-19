using System;
using System.Configuration;
using System.Data.SqlClient;
using CSVToSQL.Extensions;
using System.Data;

namespace CSVToSQL
{
    public class Course
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string AssessmentStatus { get; set; }
        public bool IsCourseRetired { get; set; }

        private static string _connectionString = null;

        static Course()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PluralsightConnectionString"].ConnectionString;

            (_connectionString.IsNullOrEmpty() || _connectionString.IsNullOrWhitespace()).ThrowIfTrue("Pluralsight connection string missing from configuration file.");
        }

        public void Save()
        {
            SaveNewCourseToDatabase();
        }

        protected virtual void SaveNewCourseToDatabase()
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var sql = "SELECT Id FROM Course WHERE Id = @Id;";
                    var command = new SqlCommand(sql, con);
                    command.Parameters.Add(new SqlParameter("@Id", this.Id));
                    var objId = command.ExecuteScalar();

                    if (objId != null)
                    {
                        Console.WriteLine("The course with Id '{0}' already exists.", this.Id);
                        return;
                    }

                    sql = "INSERT INTO Course VALUES(@Id, @Title, @DurationInSeconds, @ReleaseDate, @Description, @AssessmentStatus, @IsCourseRetired);";
                    command = new SqlCommand(sql, con);

                    command.Parameters.Add(new SqlParameter("@Id", this.Id));
                    command.Parameters.Add(new SqlParameter("@Title", this.Title));
                    command.Parameters.Add(new SqlParameter("@DurationInSeconds", this.DurationInSeconds));
                    command.Parameters.Add(new SqlParameter("@ReleaseDate", this.ReleaseDate));
                    command.Parameters.Add(new SqlParameter("@Description", this.Description));
                    command.Parameters.Add(new SqlParameter("@AssessmentStatus", this.AssessmentStatus));
                    command.Parameters.Add(new SqlParameter("@IsCourseRetired", this.IsCourseRetired));

                    var numRowsAffected = command.ExecuteNonQuery();

                    if (numRowsAffected != 1)
                        throw new Exception(string.Format("There was a problem inserting the course '{0}' ({1}) into the database.", Id, Title));

                    Console.WriteLine("Course with Id '{0}' added to the database.", this.Id);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not save course with Id '{0}'. Exception Mesage: '{1}'\n\nException ToString: {2}", 
                    this.Id, ex.Message, ex.ToString());
            }
        }
    }
}