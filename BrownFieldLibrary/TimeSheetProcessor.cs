using BrownFieldLibrary.Models;
using System;
using System.Collections.Generic;

namespace BrownFieldLibrary
{
    public static class TimeSheetProcessor
    {
        public static double GetHoursWorkedForCompany(List<TimeSheetEntryModel> timesSheets, string companyName)
        {
            double output = 0;

            for (var i = 0; i < timesSheets.Count; i++)
            {
                if (timesSheets[i].WorkDone.ToLower().Contains(companyName))
                {
                    output += timesSheets[i].HoursWorked;
                }
            }
            return output;
        }

        public static decimal CalculateEmployeePay(List<TimeSheetEntryModel> timeSheets,EmployeeModel employee)
        {
            double totalHours = 0;
            for (var i = 0; i < timeSheets.Count; i++)
                {
                    totalHours += timeSheets[i].HoursWorked;
                }

            decimal output;
            if (totalHours > 40)
            {
                output = ((decimal)(totalHours - 40) * employee.HourlyRate * 1.5M) + (40 * employee.HourlyRate);
            }
            else
            {
                output = (decimal)totalHours * employee.HourlyRate;
            }

            return output;
        }       
    }
}
