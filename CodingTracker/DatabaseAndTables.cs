using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class DatabaseAndTables
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        internal static void CreateDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                { 
                    connection.Open();
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS CodingTracker (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT, EndTime TEXT, Duration TEXT)";
                    int result = tableCmd.ExecuteNonQuery();
                }
            }
        }
        internal static void AddCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText =
                        @"INSERT INTO CodingTracker (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
                    tableCmd.Parameters.AddWithValue("@StartTime", starttime);
                    tableCmd.Parameters.AddWithValue("@EndTime", endtime);
                    tableCmd.Parameters.AddWithValue("@Duration", duration);
                    tableCmd.ExecuteNonQuery();
                }
            }
        }

        internal static void GetCodingEntries()
        {

        }
        internal static void UpdateCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @"UPDATE CodingTracker SET StartTime = @StartTime , EndTime = @EndTime , Duration = @Duration WHERE Id = @Id";
                    tableCmd.Parameters.AddWithValue("@StartTime", starttime);
                    tableCmd.Parameters.AddWithValue("@EndTime", endtime);
                    tableCmd.Parameters.AddWithValue("@Duration", duration);
                    tableCmd.Parameters.AddWithValue("@Id", id);
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
        internal static void DeleteCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @"DELETE FROM CodingTracker WHERE Id = @Id";
                    tableCmd.Parameters.AddWithValue("@Id", id);
                    tableCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
