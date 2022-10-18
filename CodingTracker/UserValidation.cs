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
        internal static int IdValidation(int id)
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

                    List<CodingSession> codingsessionsdata = new();
                    SqliteDataReader reader = tableCmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            codingsessionsdata.Add(new CodingSession
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

                    bool idexists = codingsessionsdata.Exists(x => x.Id == id);
                    if (id == 0) UserMenu.ShowUserMenu();
                    while (idexists == false)
                    {
                        Console.WriteLine("Invalid id entered, please try again.");
                        UserInput.GetCodingEntryId();
                    }
                    return id;
                }
            }
        }

        internal static string StartTimeValidation(string starttime)
        {
            return starttime;
        }
        internal static string EndTimeValidation(string endtime)
        {
            return endtime;
        }

    }
}
