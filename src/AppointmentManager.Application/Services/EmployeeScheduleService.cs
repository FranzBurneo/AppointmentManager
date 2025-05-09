using AppointmentManager.Application.DTOs.EmployeeSchedule;
using AppointmentManager.Application.Interfaces;
using AppointmentManager.Domain.Entities;
using AppointmentManager.Domain.Interfaces;
using AutoMapper;

namespace AppointmentManager.Application.Services
{
    public class EmployeeScheduleService : IEmployeeScheduleService
    {
        private readonly IRepository<EmployeeSchedule> _repository;
        private readonly IMapper _mapper;

        public EmployeeScheduleService(IRepository<EmployeeSchedule> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EmployeeSchedule?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<EmployeeSchedule> AddAsync(CreateEmployeeScheduleDto dto)
        {
            var entity = _mapper.Map<EmployeeSchedule>(dto);
            entity.Id = Guid.NewGuid();
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeScheduleDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null)
                return false;

            _mapper.Map(dto, existing);
            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}