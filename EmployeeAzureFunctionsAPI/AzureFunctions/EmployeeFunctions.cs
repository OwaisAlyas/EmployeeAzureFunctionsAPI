using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using EmployeeAzureFunctionsAPI.Shared.DTOs;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EmployeeAzureFunctionsAPI.AzureFunctions
{

    public class EmployeeFunctions
    {
        private IEmployeeService _employeeService;

        private IValidator<EmployeeModel> _employeeValidator;
        private IValidator<EmployeeSearchModel> _employeeSearchValidator;
        public EmployeeFunctions(IEmployeeService employeeService, IValidator<EmployeeModel> employeeValidator, IValidator<EmployeeSearchModel> employeeSearchValidator)
        {
            _employeeService = employeeService;
            _employeeSearchValidator = employeeSearchValidator;
            _employeeValidator = employeeValidator;
        }

        [FunctionName("GetAll")]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Employee/GetAll")] HttpRequest req,
            ILogger log)
        {
            var employees = await _employeeService.GetEmployees();
            return new OkObjectResult(employees);
        }

        [FunctionName("Create")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Employee/Create")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(requestBody);

                var result = await _employeeValidator.ValidateAsync(employeeModel);
                if (!result.IsValid)
                {
                    return new BadRequestObjectResult(result);
                }

                await _employeeService.Create(employeeModel);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }


        [FunctionName("Update")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Employee/Update/{id}")] HttpRequest req,
            int? id, ILogger log)
        {

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(requestBody);

                var result = await _employeeValidator.ValidateAsync(employeeModel);
                if (!result.IsValid)
                {
                    return new BadRequestObjectResult(result);
                }

                //Check Id Validation
                if (!id.HasValue && id != employeeModel.Id)
                {
                    return new BadRequestResult();
                }
                await _employeeService.Update(employeeModel);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [FunctionName("GetById")]
        public async Task<IActionResult> GetById(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Employee/GetById/{id}")] HttpRequest req,
         int? id, ILogger log)
        {
            //Check Id Validation
            if (!id.HasValue)
            {
                return new BadRequestResult();
            }
            var employee = await _employeeService.GetEmployeById(id.Value);
            if (employee == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(employee);
        }

        [FunctionName("Search")]
        public async Task<IActionResult> Search(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Employee/Search")] HttpRequest req,
          ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var employeeSearchModel = JsonConvert.DeserializeObject<EmployeeSearchModel>(requestBody);
            if (employeeSearchModel != null)
            {
                var result = await _employeeSearchValidator.ValidateAsync(employeeSearchModel);
                if (!result.IsValid)
                {
                    return new BadRequestObjectResult(result);
                }
            }
            else
            {
                return new BadRequestObjectResult("Object Body required");
            }

            var employees = await _employeeService.SearchEmployees(employeeSearchModel);
            return new OkObjectResult(employees);
        }

    }
}
