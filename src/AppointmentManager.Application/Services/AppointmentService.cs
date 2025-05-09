using AppointmentManager.Application.DTOs.Appointment;
using AppointmentManager.Application.Interfaces;
using AppointmentManager.Domain.Entities;
using AppointmentManager.Domain.Interfaces;
using AutoMapper;

namespace AppointmentManager.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IRepository<Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Appointment?> GetByIdAsync(Guid id)
            => await _repository.GetByIdAsync(id);

        public async Task<Appointment> AddAsync(CreateAppointmentDto dto)
        {
            var entity = _mapper.Map<Appointment>(dto);
            entity.Id = Guid.NewGuid();
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(UpdateAppointmentDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}