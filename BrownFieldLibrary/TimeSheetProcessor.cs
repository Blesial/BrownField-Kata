using ConsoleUI;
using System;
using System.Collections.Generic;

namespace BrownFieldLibrary
{
    public static class TimeSheetProcessor
    {
        public static double GetHoursWorkedForCompany(List<TimeSheetEntry> timesSheets, string companyName)
        {
            double output = 0;

            for (var i = 0; i < timesSheets.Count; i++)
            {
                if (timesSheets[i].WorkDone.ToLower().Contains(companyName))
                {
                    output += timesSheets[i].HoursWorked;
                }
            }
        }

        public static double GetHoursWorkedForCompany(string v)
        {
            throw new NotImplementedException();
        }
    }
}
