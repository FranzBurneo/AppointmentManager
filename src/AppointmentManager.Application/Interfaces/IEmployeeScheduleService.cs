using AppointmentManager.Domain.Entities;

namespace AppointmentManager.Application.Interfaces
{
    public interface IEmployeeScheduleService
    {
        Task<IEnumerable<EmployeeSchedule>> GetAllAsync();
        Task<EmployeeSchedule?> GetByIdAsync(Guid id);
        Task AddAsync(EmployeeSchedule schedule);
        Task UpdateAsync(EmployeeSchedule schedule);
        Task DeleteAsync(EmployeeSchedule schedule);
    }
}