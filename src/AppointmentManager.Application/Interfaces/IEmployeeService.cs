using AppointmentManager.Application.DTOs.Employee;
using AppointmentManager.Domain.Entities;

namespace AppointmentManager.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(Guid id);
        Task<Employee> AddAsync(CreateEmployeeDto dto);
        Task<bool> UpdateAsync(UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(Employee employee);
    }
}