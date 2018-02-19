using System.Configuration;
using CSVToSQL.Extensions;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CSVToSQL
{
    public class Tag
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        private static string _connectionString = null;

        static Tag()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PluralsightConnectionString"].ConnectionString;

            (_connectionString.IsNullOrEmpty() || _connectionString.IsNullOrWhitespace()).ThrowIfTrue("Pluralsight connection string missing from configuration file.");
        }

        public void Save()
        {
            SaveNewTagToDatabase();
        }

        protected virtual void SaveNewTagToDatabase()
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var sql = "SELECT Id FROM Tag WHERE Id = @Id;";
                    var command = new SqlCommand(sql, con);
                    command.Parameters.Add(new SqlParameter("@Id", this.Id));
                    var objId = command.ExecuteScalar();

                    if (objId != null)
                    {
                        Console.WriteLine("The tag with Id '{0}' already exists.", this.Id);
                        return;
                    }

                    sql = "INSERT INTO Tag VALUES(@Id, @DisplayName, @Description);";
                    command = new SqlCommand(sql, con);

                    command.Parameters.Add(new SqlParameter("@Id", this.Id));
                    command.Parameters.Add(new SqlParameter("@DisplayName", this.DisplayName));
                    command.Parameters.Add(new SqlParameter("@Description", this.Description));
                    
                    var numRowsAffected = command.ExecuteNonQuery();

                    if (numRowsAffected != 1)
                        throw new Exception(string.Format("There was a problem inserting the tag '{0}' ({1}) into the database.", Id, DisplayName));

                    Console.WriteLine("Tag with Id '{0}' added to the database.", this.Id);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not save tag with Id '{0}'. Exception Mesage: '{1}'\n\nException ToString: {2}", 
                    this.Id, ex.Message, ex.ToString());
            }
        }
    }
}