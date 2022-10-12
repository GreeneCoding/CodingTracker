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
        }
        internal static string GetStartTime()
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string StartTime = Console.ReadLine();
            return StartTime;
        }

        internal static string GetEndTime()
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string EndTime = Console.ReadLine();
            return EndTime;
        }
    }
}
