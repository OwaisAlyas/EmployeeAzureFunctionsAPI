using EmployeeAzureFunctionsAPI.Shared.DTOs;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAzureFunctionsAPI.Shared.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeModel>> GetEmployees();
        public Task Create(EmployeeModel employeeModel);
        public Task Update(EmployeeModel employeeModel);
        public Task<EmployeeModel> GetEmployeById(int id);
        public Task<IEnumerable<EmployeeModel>> SearchEmployees(EmployeeSearchModel employeeSearchModel);



    }
}
