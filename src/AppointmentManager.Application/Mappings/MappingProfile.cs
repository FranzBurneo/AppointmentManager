using AutoMapper;
using AppointmentManager.Application.DTOs.Company;
using AppointmentManager.Application.DTOs.Employee;
using AppointmentManager.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AppointmentManager.Application.DTOs.EmployeeSchedule;

namespace AppointmentManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            CreateMap<CreateEmployeeScheduleDto, EmployeeSchedule>();
            CreateMap<UpdateEmployeeScheduleDto, EmployeeSchedule>();
        }
    }
}