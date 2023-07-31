using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using EmployeeAzureFunctionsAPI.Shared.DTOs;

namespace EmployeeAzureFunctionsAPI.Shared.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>?> GetEmployees();
        public Task<Employee?> GetEmployeById(int id);
        public Task CreateEmployee(Employee employee);
        public Task UpdateEmployee(Employee employee);
        public Task<IEnumerable<Employee>> SearchEmployees(EmployeeSearchModel employee);

    }
}
