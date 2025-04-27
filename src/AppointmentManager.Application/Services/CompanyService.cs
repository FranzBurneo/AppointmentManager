using AppointmentManager.Application.DTOs;
using AppointmentManager.Application.Interfaces;
using AppointmentManager.Domain.Entities;

namespace AppointmentManager.Application.Services;

public class CompanyService(IRepository<Company> repository) : ICompanyService
{
    private readonly IRepository<Company> _repository = repository;

    public async Task<IEnumerable<CompanyDto>> GetAllAsync()
    {
        var companies = await _repository.GetAllAsync();
        return companies.Select(c => new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            Address = c.Address,
            Phone = c.Phone,
            IsActive = c.IsActive
        });
    }

    public async Task<CompanyDto?> GetByIdAsync(Guid id)
    {
        var company = await _repository.GetByIdAsync(id);
        if (company is null) return null;

        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address,
            Phone = company.Phone,
            IsActive = company.IsActive
        };
    }

    public async Task<CompanyDto> CreateAsync(CompanyDto dto)
    {
        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Phone = dto.Phone,
            IsActive = dto.IsActive
        };

        await _repository.AddAsync(company);
        dto.Id = company.Id;
        return dto;
    }

    public async Task<bool> UpdateAsync(CompanyDto dto)
    {
        var company = await _repository.GetByIdAsync(dto.Id);
        if (company is null) return false;

        company.Name = dto.Name;
        company.Address = dto.Address;
        company.Phone = dto.Phone;
        company.IsActive = dto.IsActive;

        return await _repository.UpdateAsync(company);
    }

    public async Task<bool> DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}