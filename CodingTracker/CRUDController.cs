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
        static string connectionString = ConfigurationManager.AppSettings.Get("database"); 
        internal static void AddCodingEntry()
        {
            string starttime = UserInput.GetStartTime();
            string endtime = UserInput.GetEndTime();
            string duration = UserInput.GetDuration(starttime,endtime);
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
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @"SELECT * FROM CodingTracker";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
        internal static void UpdateCodingEntry()
        {
            string starttime = UserInput.GetStartTime();
            string endtime = UserInput.GetEndTime();
            string duration = UserInput.GetDuration(starttime,endtime);
            int id = UserInput.GetCodingEntryId();
            using (var connection = new SqliteConnection(connectionString))
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
        internal static void DeleteCodingEntry()
        {
            int id = UserInput.GetCodingEntryId();
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
