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
        void AddCodingEntry()
        {
            using (var connection = new SqliteConnection(connectionstring))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText =
                        @"INSERT INTO CodingTracker (Id INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT, EndTime TEXT, Duration STRING)";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
