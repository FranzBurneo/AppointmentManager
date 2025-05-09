using AppointmentManager.Application.DTOs.Appointment;
using AppointmentManager.Domain.Entities;

namespace AppointmentManager.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<Appointment> AddAsync(CreateAppointmentDto dto);
        Task<bool> UpdateAsync(UpdateAppointmentDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}