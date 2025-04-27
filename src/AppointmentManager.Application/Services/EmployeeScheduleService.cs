using AppointmentManager.Application.Interfaces;
using AppointmentManager.Domain.Entities;
using AppointmentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManager.Application.Services
{
    public class EmployeeScheduleService : IEmployeeScheduleService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetAllAsync()
        {
            return await _context.EmployeeSchedules.ToListAsync();
        }

        public async Task<EmployeeSchedule?> GetByIdAsync(Guid id)
        {
            return await _context.EmployeeSchedules.FindAsync(id);
        }

        public async Task AddAsync(EmployeeSchedule schedule)
        {
            _context.EmployeeSchedules.Add(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeSchedule schedule)
        {
            _context.EmployeeSchedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EmployeeSchedule schedule)
        {
            _context.EmployeeSchedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }
    }
}