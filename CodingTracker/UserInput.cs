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

        internal static string GetEndTime()
        {
            Console.WriteLine(@"Please enter a date and time in the following format: MM/DD/YYYY 23:59");
            string endTime = Console.ReadLine();

            bool validEnd = UserValidation.EndTimeValidation(endTime);
            if (endTime == "0") UserMenu.ShowUserMenu();
            while (validEnd == false)
            {
                Console.WriteLine("Invalid start time, please try again - MM/DD/YYYY 23:59");
                endTime = Console.ReadLine();
                validEnd = UserValidation.StartTimeValidation(endTime);
            }
            return endTime;
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
