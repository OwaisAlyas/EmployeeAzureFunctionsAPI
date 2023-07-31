using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;
using FluentValidation;
using System;

namespace EmployeeAzureFunctionsAPI.Shared.DTOs
{
    public class EmployeeSearchModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }

    public class EmployeeSearchModelValidator : AbstractValidator<EmployeeSearchModel>
    {
        public EmployeeSearchModelValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(100);
            RuleFor(x => x.SurName).MaximumLength(100);
            RuleFor(x => x.JobTitle).MaximumLength(100);
            RuleFor(x => x.Email).EmailAddress().MaximumLength(50);
        }
    }
}
