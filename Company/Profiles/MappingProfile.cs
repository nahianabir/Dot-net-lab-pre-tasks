using AutoMapper;
using Company.DTOS;
using Company.EF.Tables;

namespace Company.Profiles

{
    public class MappingProfile: Profile
    {
        public MappingProfile() {

            CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.DepartmentName, 
                opt => opt.MapFrom(src => src.Department.DepartmentName));

            CreateMap<EmployeeSaveDTO, Employee>();
        }
    }
}
