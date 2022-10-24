using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserValidation
    {
        internal static bool IdValidation(int id)
        {
            string? connectionString = ConfigurationManager.AppSettings.Get("database");
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @"SELECT Id FROM CodingTracker WHERE @Id = id";
                    tableCmd.Parameters.AddWithValue("@Id", id);
                    tableCmd.ExecuteNonQuery();

                    List<CodingSession> codingSessionsData = new();
                    SqliteDataReader reader = tableCmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            codingSessionsData.Add(new CodingSession
                            {
                                Id = reader.GetInt32(0)
                            }

                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n No rows found.");
                    }

                    bool idExists = codingSessionsData.Exists(x => x.Id == id);
                    
                    return idExists;
                }
            }
        }

        internal static bool StartTimeValidation(string startTime)
        {
            bool validStartTime = DateTime.TryParseExact(startTime,"MM/dd/yyyy HH:mm",new CultureInfo("en-US"),DateTimeStyles.None, out _);
            return validStartTime;
        }
        internal static bool EndTimeValidation(string endTime, string startTime)
        {
            bool validEndTime = DateTime.TryParseExact(endTime, "MM/dd/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _) && Convert.ToDateTime(endTime) > Convert.ToDateTime(startTime);
            
            return validEndTime;
        }


    }
}
