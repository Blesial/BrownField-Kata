using System;
using System.Collections.Generic;
using BrownFieldLibrary;
using BrownFieldLibrary.Models;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalHours;

            List<TimeSheetEntryModel> timeSheets = LoadTimeSheets();

            List<CustomerModel> customers = DataAccess.GetCustomers();

            customers.ForEach(x => BillCustomer(timeSheets, x)); // Delegate

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

        private static void BillCustomer(List<TimeSheetEntryModel> timeSheets, CustomerModel customer)
        {
            double totalHours = TimeSheetProcessor.GetHoursWorkedForCompany(timeSheets, customer.Name);
            Console.WriteLine($"Simulating Sending email to { customer.Name }");
            Console.WriteLine("Your bill is $" + ((decimal)totalHours * customer.HourlyRate) + " for the hours worked.");

        }

        private static List<TimeSheetEntryModel> LoadTimeSheets()
        {
            List<TimeSheetEntryModel> output = new List<TimeSheetEntryModel>();
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

                var timeSheet = new TimeSheetEntryModel
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
