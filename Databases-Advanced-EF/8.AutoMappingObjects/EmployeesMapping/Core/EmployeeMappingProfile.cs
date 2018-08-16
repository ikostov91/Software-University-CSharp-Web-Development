using AutoMapper;
using EmployeesMapping.App.Core.Dtos;
using EmployeesMapping.Models;

namespace EmployeesMapping.App.Core
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>().
                ForMember(dest => dest.EmployeesDto, from => from.MapFrom(x => x.ManagerEmployees)).ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
        }
    }
}
