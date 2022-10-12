﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserMenu
    {
        internal static void ShowUserMenu()
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
                    case "0":
                        Console.WriteLine(@"Thank you for using the Coding Tracker App, Goodbye!");
                        closeApp = true;
                        break;   
                    case "1":
                        Console.Clear();
                        CRUDController.AddCodingEntry();
                        break;
                    case "2":
                        Console.Clear();
                        CRUDController.GetCodingEntries();
                        break;
                    case "3":
                        Console.Clear();
                        CRUDController.UpdateCodingEntry();
                        break;
                    case "4":
                        Console.Clear();
                        CRUDController.DeleteCodingEntry();
                        break;
                    default:
                        Console.WriteLine(@"Invalid input, please enter a value from 0-4");
                        break;
                }
            }
            
        }
    }
}