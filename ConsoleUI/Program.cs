using BrownFieldLibrary;
using System;
using System.Collections.Generic;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TimeSheetEntry> timeSheets = LoadTimeSheets();

            double acmeHoursWorked = TimeSheetProcessor.GetHoursWorkedForCompany(timeSheets, "acme");
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + acmeHoursWorked * 150 + " for the hours worked.");

            double abcHoursWorked = TimeSheetProcessor.GetHoursWorkedForCompany(timeSheets, "abc");
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + abcHoursWorked * 125 + " for the hou  worked.");

            double ttl = 0;
            for (var i = 0; i < timeSheets.Count; i++)
            {
                ttl += timeSheets[i].HoursWorked;
            }
            if (ttl > 40)
            {
                Console.WriteLine("You will get paid $" + (((ttl - 40) * 15) + (40 * 10)) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + ttl * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static List<TimeSheetEntry> LoadTimeSheets()
        {
            List<TimeSheetEntry> output = new List<TimeSheetEntry>();
            string enterMoreTimeSheets;

            do
            {
                Console.Write("Enter what you did: ");
                string workDone = Console.ReadLine();
                Console.Write("How long did you do it for: ");
                string rawTimeWorked = Console.ReadLine();

                double hoursWorked;

                while (double.TryParse(rawTimeWorked, out hoursWorked) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number given");
                    Console.Write("How long did you do it for: ");
                    rawTimeWorked = Console.ReadLine();
                }

                TimeSheetEntry timeSheet = new TimeSheetEntry();
                timeSheet.HoursWorked = hoursWorked;
                timeSheet.WorkDone = workDone;
                output.Add(timeSheet);

                Console.Write("Do you want to enter more time (yes/no): ");

                enterMoreTimeSheets = Console.ReadLine();

            } while (enterMoreTimeSheets.ToLower() == "yes");

            return output;
        }
    }
}
