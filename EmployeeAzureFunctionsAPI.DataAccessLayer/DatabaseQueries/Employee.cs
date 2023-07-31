using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAzureFunctionsAPI.DataAccessLayer.DatabaseQueries
{
    public static class EmployeeQueries
    {
        public static string GetById = @"GetEmployeeById";
        public static string GetAll = @"GetAllEmployees";
        public static string SearchEmployees = @"SearchEmployees";
        public static string Create = @"CreateEmployee";
        public static string Update = @"UpdateEmployee";
    }
}
