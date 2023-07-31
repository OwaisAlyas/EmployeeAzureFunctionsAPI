using AutoMapper;
using EmployeeAzureFunctionsAPI.BusinessLayer.Services;
using EmployeeAzureFunctionsAPI.DataAccessLayer.ContextClasses;
using EmployeeAzureFunctionsAPI.DataAccessLayer.Repositories;
using EmployeeAzureFunctionsAPI.Shared.DTOs;
using EmployeeAzureFunctionsAPI.Shared.Interfaces;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Repositories;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Services;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using Moq;
using System.Net.Sockets;

namespace EmployeeAzureFunctionsAPI.Test
{
    public class Tests
    {

        private IAppDbContext _context;
        private IEmployeeRepository _employeeRepository;

        [SetUp]
        public void Setup()
        {
            _context = new EmployeeDbContext();
            _employeeRepository = new EmployeeRepository(_context);
        }

        [Test]
        public void GetAllEmployeeTestCase()
        {
            var result = _employeeRepository.GetEmployees();
            Assert.AreEqual(true, (result != null));
        }
        [Test]
        public void GetEmployeeByIdTestCase()
        {
            int id = 1;
            var result = _employeeRepository.GetEmployeById(id);

            Assert.AreEqual(true, (result != null));
        }

        [Test]
        public async Task CreateEmployeeTestCase()
        {
            Employee employee = new Employee();
            employee.FirstName = "Awais Alyas";
            employee.SurName = "Rathore";
            employee.Email = "Raj@aa.com";
            employee.JobTitle = "Engineer";
            employee.StartDate = DateTime.Now;

            var result = _employeeRepository.CreateEmployee(employee);
            Assert.AreEqual(true, (result != null));
        }
        [Test]
        public async Task UpdateEmployeeTestCase()
        {
            Employee employee = new Employee();
            employee.Id = 1;
            employee.FirstName = "Awais Alyas";
            employee.SurName = "Rathore";
            employee.Email = "Raj@aa.com";
            employee.JobTitle = "Engineer";
            employee.StartDate = DateTime.Now;

            var result = _employeeRepository.UpdateEmployee(employee);
            Assert.AreEqual(true, (result != null));
        }

    }
}
