using System;
using System.Collections.Generic;
using BrownFieldLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalHours;

            List<TimeSheetEntry> timeSheets = LoadTimeSheets();

            BillCustomer(timeSheets, "Acme", 150);

            BillCustomer(timeSheets, "Abc", 125);

            totalHours = 0;
            for (var i = 0; i < timeSheets.Count; i++)
            {
                totalHours += timeSheets[i].HoursWorked;
            }
            if (totalHours > 40)
            {
                Console.WriteLine("You will get paid $" + (((totalHours - 40) * 15) + (40 * 10)) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + totalHours * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static void BillCustomer(List<TimeSheetEntry> timeSheets, string companyName, decimal hourlyRate)
        {
            double totalHours = TimeSheetProcessor.GetHoursWorkedForCompany(timeSheets, companyName);
            Console.WriteLine($"Simulating Sending email to { companyName }");
            Console.WriteLine("Your bill is $" + ((decimal)totalHours * hourlyRate) + " for the hours worked.");
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

                var timeSheet = new TimeSheetEntry
                {
                    HoursWorked = hoursWorked,
                    WorkDone = workDone
                };
                output.Add(timeSheet);

                Console.Write("Do you want to enter more time (yes/no): ");

                enterMoreTimeSheets = Console.ReadLine();

            } while (enterMoreTimeSheets.ToLower() == "yes");

            return output;
        }
    }
}
