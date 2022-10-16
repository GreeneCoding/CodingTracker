using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserValidation
    {
        internal static int IdValidation(int id, List<CodingSession> codingsessionsdata)
        {
            bool idexists = codingsessionsdata.Exists(x=> x.Id == id);
            if (id == 0) UserMenu.ShowUserMenu();
            while (idexists == false)
            {
                Console.WriteLine("Invalid id entered, please try again.");
                UserInput.GetCodingEntryId();
            }
            return id;
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
