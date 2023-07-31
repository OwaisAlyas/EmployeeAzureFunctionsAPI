using AutoMapper;
using EmployeeAzureFunctionsAPI.Shared.DTOs;
using EmployeeAzureFunctionsAPI.DomainLayer.DBModels;

namespace EmployeeAzureFunctionsAPI.BusinessLayer
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
