using System.Data;

namespace EmployeeAzureFunctionsAPI.Shared.Interfaces
{
    public interface IAppDbContext
    {
        public IDbConnection CreateConnection();
    }
}
