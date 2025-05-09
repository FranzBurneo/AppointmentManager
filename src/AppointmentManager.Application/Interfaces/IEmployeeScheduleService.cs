using AppointmentManager.Application.DTOs.EmployeeSchedule;
using AppointmentManager.Domain.Entities;

namespace AppointmentManager.Application.Interfaces
{
    public interface IEmployeeScheduleService
    {
        Task<IEnumerable<EmployeeSchedule>> GetAllAsync();
        Task<EmployeeSchedule?> GetByIdAsync(Guid id);
        Task<EmployeeSchedule> AddAsync(CreateEmployeeScheduleDto dto);
        Task<bool> UpdateAsync(UpdateEmployeeScheduleDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}