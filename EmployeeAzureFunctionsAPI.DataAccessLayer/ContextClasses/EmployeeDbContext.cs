using EmployeeAzureFunctionsAPI.Shared.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace EmployeeAzureFunctionsAPI.DataAccessLayer.ContextClasses
{
    public class EmployeeDbContext : IAppDbContext
    {
        private string? _connectionString = string.Empty;
        public EmployeeDbContext()
        {
            _connectionString = Environment.GetEnvironmentVariable("ConnectionString:AppDbSqlServer");
            if (_connectionString == null)
            {
                _connectionString = "Data Source=AWAIS; Initial Catalog=Employee;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True";
            }
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new Exception("Unable to locate DB connection details.");
            }
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
