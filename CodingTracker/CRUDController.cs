using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class CRUDController
    {
        static string connectionstring = ConfigurationManager.AppSettings.Get("database");
       internal void AddCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionstring))
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
        internal void GetCodingEntries() 
        {
            using (var connection = new SqliteConnection(connectionstring))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @"SELECT * FROM CodingTracker";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
        internal void UpdateCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionstring))
            {
                using (var tableCmd = connection.CreateCommand()) 
                {
                    connection.Open();
                    tableCmd.CommandText = @"UPDATE CodingTracker SET StartTime = @StartTime , EndTime = @EndTime , Duration = WHERE Id = @Id";
                    tableCmd.Parameters.AddWithValue("@StartTime", starttime);
                    tableCmd.Parameters.AddWithValue("@EndTime", endtime);
                    tableCmd.Parameters.AddWithValue("@Duration", duration);
                    tableCmd.Parameters.AddWithValue("@Id", id);
                }
            }
        }
        internal void DeleteCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionstring))
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
