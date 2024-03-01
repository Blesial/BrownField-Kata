using BrownFieldLibrary.Models;
using System.Collections.Generic;

namespace BrownFieldLibrary
{
    public static class DataAccess
    {
        // Simulating Retrieving the data from a "db"

        public static List<CustomerModel> GetCustomers()
        {
           var output = new List<CustomerModel>();

            output.Add(new CustomerModel() { Name = "Acme", HourlyRate = 150 });
            output.Add(new CustomerModel() { Name = "Abc", HourlyRate = 125 });

            return output;
        }

        public static EmployeeModel GetCurrentEmployee()
        {
            EmployeeModel output = new EmployeeModel
            {
                FirstName = "Chon",
                LastName = "Quire",
                HourlyRate = 15
            };

            return output;
        }
    }
}
     