using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class CRUDProcesses
    {
        static string? connectionString = ConfigurationManager.AppSettings.Get("database");
        internal static void AddProcess()
        {
            string starttime = UserInput.GetStartTime();
            string endtime = UserInput.GetEndTime();
            string duration = UserInput.GetDuration(starttime, endtime);
            
        }
        internal static void ReadProcess()
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
        internal static void UpdateProcess()
        {
            int id = UserInput.GetCodingEntryId();
            string starttime = UserInput.GetStartTime();
            string endtime = UserInput.GetEndTime();
            string duration = UserInput.GetDuration(starttime, endtime);
        }
        internal static void DeleteProcess()
        {
            int id = UserInput.GetCodingEntryId();
        }



    }
}
