using AppointmentManager.Application.DTOs.Company;
using AppointmentManager.Application.Interfaces;
using AppointmentManager.Domain.Entities;
using AppointmentManager.Domain.Interfaces;
using AppointmentManager.Infrastructure.Data;
using AutoMapper;

namespace AppointmentManager.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Company> _repository;

        public CompanyService(IRepository<Company> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Company?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Company> AddAsync(CreateCompanyDto dto)
        {
            var company = _mapper.Map<Company>(dto);
            company.Id = Guid.NewGuid();
            company.IsActive = true;
            return await _repository.AddAsync(company);
        }

        public async Task<bool> UpdateAsync(UpdateCompanyDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null)
                return false;

            _mapper.Map(dto, existing);
            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(Company company)
        {
            return await _repository.DeleteAsync(company.Id);
        }
    }
}