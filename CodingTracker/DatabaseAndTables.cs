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
       internal static void CreateDatabase()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("database");
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                { 
                    connection.Open();
                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS CodingTracker (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT, EndTime TEXT, Duration TEXT)";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
