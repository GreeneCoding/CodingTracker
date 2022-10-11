using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserMenu
    {
        internal void ShowUserMenu()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine(@"\nWelcome to the CodingTracker App, please select one of the following options from 0 - 4");
                Console.WriteLine(@"\nType 1 to create a new coding entry.");
                Console.WriteLine(@"\nType 2 to view all coding Entries.");
                Console.WriteLine(@"\nType 3 to update a coding entry.");
                Console.WriteLine(@"\nType 4 to delete a coding entry.");
                Console.WriteLine(@"\nType 0 to exit the app.");

                var commandinput = Console.ReadLine();
                switch (commandinput)
                {
                    case "1":
                        Console.Clear();
                        CRUDController.AddCodingEntry();
                }
            }
            
        }
    }
}
