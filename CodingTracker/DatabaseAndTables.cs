using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class DatabaseAndTables
    {
       static string connectionstring = ConfigurationManager.AppSettings.Get("database");

       internal static void CreateDatabase()
        {
            using (var connection = new SqliteConnection(connectionstring))
            {
                using (var tableCmd = connection.CreateCommand())
                { 
                    connection.Open();
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS CodingTracker (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT, EndTime TEXT, Duration STRING)";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
