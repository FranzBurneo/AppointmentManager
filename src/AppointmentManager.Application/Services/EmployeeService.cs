using AppointmentManager.Application.DTOs.Employee;
using AppointmentManager.Application.Interfaces;
using AppointmentManager.Domain.Entities;
using AppointmentManager.Domain.Interfaces;
using AutoMapper;

namespace AppointmentManager.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee> AddAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            employee.Id = Guid.NewGuid();

            await _repository.AddAsync(employee);
            return employee;
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);

            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            return await _repository.DeleteAsync(employee.Id);
        }
    }
}