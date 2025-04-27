using AppointmentManager.Application.DTOs;

namespace AppointmentManager.Application.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllAsync();
    Task<CompanyDto?> GetByIdAsync(Guid id);
    Task<CompanyDto> CreateAsync(CompanyDto company);
    Task<bool> UpdateAsync(CompanyDto company);
    Task<bool> DeleteAsync(Guid id);
}