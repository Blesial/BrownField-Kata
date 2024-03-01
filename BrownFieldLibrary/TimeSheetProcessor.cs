using BrownFieldLibrary.Models;
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
    }
}
