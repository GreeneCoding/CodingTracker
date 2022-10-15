using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserInput
    {
        internal static int GetCodingEntryId()
        {
            Console.WriteLine(@"Please enter the Id of the record in the table below");
            CRUDController.GetCodingEntries();
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        internal static string GetStartTime()
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string starttime = Console.ReadLine();
            return starttime;
        }

        internal static string GetEndTime()
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string endtime = Console.ReadLine();
            return endtime;
        }
        internal static string GetDuration(string starttime, string endtime)
        {
            //var starttime = Convert.ToDateTime(GetStartTime());
            //var endtime = Convert.ToDateTime(GetEndTime());
            var duration = Convert.ToDateTime(endtime) - Convert.ToDateTime(starttime);
            return duration.ToString();
        }
    }
}
