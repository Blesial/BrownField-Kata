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
            List<TimeSheetEntryModel> timeSheets = LoadTimeSheets();

            List<CustomerModel> customers = DataAccess.GetCustomers();

            EmployeeModel currentEmployee = DataAccess.GetCurrentEmployee();

            customers.ForEach(x => BillCustomer(timeSheets, x)); // Delegate

            PayEmployee(timeSheets, currentEmployee);

            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static void PayEmployee(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        {
            decimal totalPay = TimeSheetProcessor.CalculateEmployeePay(timeSheets, employee);
          
                Console.WriteLine($"You will get paid ${totalPay} for your time.");
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

            Console.WriteLine();

            return output;
        }
    }
}
