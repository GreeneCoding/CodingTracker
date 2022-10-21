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
            CRUDController.AddCodingEntry(starttime, endtime, duration);
            
        }
        internal static void ReadProcess()
        {
            CRUDController.GetCodingEntries();
        }
        internal static void UpdateProcess()
        {
            int id = UserInput.GetCodingEntryId();
            string starttime = UserInput.GetStartTime();
            string endtime = UserInput.GetEndTime();
            string duration = UserInput.GetDuration(starttime, endtime);
            CRUDController.UpdateCodingEntry(id,starttime,endtime,duration);
        }
        internal static void DeleteProcess()
        {
            int id = UserInput.GetCodingEntryId();
            CRUDController.DeleteCodingEntry(id);
        }



    }
}
