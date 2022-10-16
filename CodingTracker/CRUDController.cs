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
        static string? connectionString = ConfigurationManager.AppSettings.Get("database"); 
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
                    
                    List<CodingSession> codingsessionsdata = new();
                    SqliteDataReader reader = tableCmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            codingsessionsdata.Add(new CodingSession
                            {
                                Id = reader.GetInt32(0),
                                StartTime = reader.GetDateTime(1),
                                EndTime = reader.GetDateTime(2),
                                Duration = reader.GetString(3)
                            }

                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n No rows found.");
                    }
                    TableVisualizationEngine.DisplayCodingTracker(codingsessionsdata);

                }
            }
        }
        internal static void UpdateCodingEntry(List<CodingSession> codingsessionsdata)
        {
            int id = UserInput.GetCodingEntryId(codingsessionsdata);
            string starttime = UserInput.GetStartTime();
            string endtime = UserInput.GetEndTime();
            string duration = UserInput.GetDuration(starttime,endtime);
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
        internal static void DeleteCodingEntry(List<CodingSession> codingsessionsdata)
        {
            int id = UserInput.GetCodingEntryId(codingsessionsdata);
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
