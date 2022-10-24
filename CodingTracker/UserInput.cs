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
            string input = Console.ReadLine();
            while (!int.TryParse(input, out _) || Convert.ToInt32(input) < 0)
            {
                Console.WriteLine("Invalid id entered, please try again.");
                input = Console.ReadLine();
            }
            int id = Convert.ToInt32(input);

            bool idExists = UserValidation.IdValidation(id);
            if (id == 0) UserMenu.ShowUserMenu();
            while (idExists == false)
            {
                Console.WriteLine("Invalid id entered, please try again.");
                id = Convert.ToInt32(Console.ReadLine());
                idExists = UserValidation.IdValidation(id);
            }
            return id;
        }
        internal static string GetStartTime()
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string startTime = Console.ReadLine();

            bool validStart = UserValidation.StartTimeValidation(startTime);
            if (startTime == "0") UserMenu.ShowUserMenu();
            while (validStart == false)
            {
                Console.WriteLine("Invalid start time, please try again - MM/DD/YYYY 23:59");
                startTime = Console.ReadLine();
                validStart = UserValidation.StartTimeValidation(startTime);
            }

            return startTime;
        }

        internal static string GetEndTime(string startTime)
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string endTime = Console.ReadLine();

            bool validEnd = UserValidation.EndTimeValidation(endTime,startTime);
            if (endTime == "0") UserMenu.ShowUserMenu();
            while (validEnd == false)
            {
                Console.WriteLine("Invalid end time, or end time is further in the past than start time, please try again - MM/DD/YYYY 23:59");
                endTime = Console.ReadLine();
                validEnd = UserValidation.EndTimeValidation(endTime,startTime);
            }
            return endTime;
        }
        internal static string GetDuration(string starttime, string endtime)
        {
            var duration = Convert.ToDateTime(endtime) - Convert.ToDateTime(starttime);
            return duration.ToString();
        }
    }
}
