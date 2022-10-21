using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        internal static string StartTimeValidation(string startTime)
        {
            return startTime;
        }
        internal static string EndTimeValidation(string endTime)
        {
            return endTime;
        }

    }
}
