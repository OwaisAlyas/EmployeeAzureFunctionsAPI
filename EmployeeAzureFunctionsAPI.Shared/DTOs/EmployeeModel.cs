using FluentValidation;
using System;

namespace EmployeeAzureFunctionsAPI.Shared.DTOs
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ProfileImage { get; set; }

    }
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 100);
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.SurName).Length(1, 100);
            RuleFor(x => x.SurName).NotNull();
            RuleFor(x => x.JobTitle).Length(2, 100);
            RuleFor(x => x.Email).EmailAddress().Length(2, 50); ;
            RuleFor(x => x.StartDate).NotNull();
        }
    }
}
