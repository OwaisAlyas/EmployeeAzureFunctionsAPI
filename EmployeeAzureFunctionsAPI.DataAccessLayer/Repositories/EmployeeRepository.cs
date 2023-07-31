using Dapper;
using EmployeeAzureFunctionsAPI.DataAccessLayer.DatabaseQueries;
using EmployeeAzureFunctionsAPI.Shared.Interfaces;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Repositories;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;
using FluentValidation;
using Microsoft.Data.SqlClient;
using System.Data;
using EmployeeAzureFunctionsAPI.Shared.DTOs;

namespace EmployeeAzureFunctionsAPI.DataAccessLayer.Repositories
{


    public class EmployeeRepository : IEmployeeRepository
    {
        private IAppDbContext _context;

        public EmployeeRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmployee(Employee employee)
        {
            string query = EmployeeQueries.Create;
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    FirstName = employee.FirstName,
                    SurName = employee.SurName,
                    Email = employee.Email,
                    JobTitle = employee.JobTitle,
                    StartDate = employee.StartDate,
                    EndDate = employee.EndDate,
                    ProfileImage = employee.ProfileImage

                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(EmployeeSearchModel employee)
        {
            string query = EmployeeQueries.SearchEmployees;
            using (var connection = _context.CreateConnection())
            {
                // Call the stored procedure with the filter parameters
                var parameters = new
                {
                    employee?.Id,
                    employee?.FirstName,
                    employee?.SurName,
                    employee?.Email,
                    employee?.JobTitle,
                    employee?.StartDate,
                    employee?.EndDate
                };

                var employees = await connection.QueryAsync<Employee>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return employees;
            }

        }

        public async Task UpdateEmployee(Employee employee)
        {
            string query = EmployeeQueries.Update;
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, employee, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<Employee?> GetEmployeById(int id)
        {
            string query = EmployeeQueries.GetById;
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id }, commandType: System.Data.CommandType.StoredProcedure);
                return employee;
            }
        }

        public async Task<IEnumerable<Employee>?> GetEmployees()
        {
            string query = EmployeeQueries.GetAll;
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query, commandType: System.Data.CommandType.StoredProcedure);
                return employees;
            }
        }

    }
}
