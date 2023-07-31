using AutoMapper;
using EmployeeAzureFunctionsAPI.Shared.DTOs;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Repositories;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Services;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using System.Collections.Generic;

namespace EmployeeAzureFunctionsAPI.BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task Create(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);
            await _employeeRepository.CreateEmployee(employee);
        }

        public async Task Update(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);
            await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var res = await _employeeRepository.GetEmployees();
            var employees = _mapper.Map<IEnumerable<EmployeeModel>>(res);
            return employees;
        }

        public async Task<IEnumerable<EmployeeModel>> SearchEmployees(EmployeeSearchModel employeeSearchModel)
        {
            var res = await _employeeRepository.SearchEmployees(employeeSearchModel);
            var employees = _mapper.Map<IEnumerable<EmployeeModel>>(res);
            return employees;
        }

        public async Task<EmployeeModel> GetEmployeById(int id)
        {
            var res = await _employeeRepository.GetEmployeById(id);
            var employees = _mapper.Map<EmployeeModel>(res);
            return employees;
        }
    }
}
