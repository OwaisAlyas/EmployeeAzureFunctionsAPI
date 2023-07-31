
using AutoMapper;
using EmployeeAzureFunctionsAPI.BusinessLayer.Services;
using EmployeeAzureFunctionsAPI.DataAccessLayer.ContextClasses;
using EmployeeAzureFunctionsAPI.DataAccessLayer.Repositories;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using EmployeeAzureFunctionsAPI.Shared.DTOs;
using EmployeeAzureFunctionsAPI.Shared.Interfaces;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Repositories;
using EmployeeAzureFunctionsAPI.Shared.Interfaces.Services;
using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(EmployeeAzureFunctionsAPI.Startup))]
namespace EmployeeAzureFunctionsAPI
{


    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IAppDbContext, EmployeeDbContext>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IValidator<EmployeeModel>, EmployeeModelValidator>();
            builder.Services.AddScoped<IValidator<EmployeeSearchModel>, EmployeeSearchModelValidator>();
        }

    }

}
