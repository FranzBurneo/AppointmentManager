using AppointmentManager.Application.DTOs.Company;
using AppointmentManager.Domain.Entities;

namespace AppointmentManager.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(Guid id);
        Task<Company> AddAsync(CreateCompanyDto dto); // <- debe coincidir
        Task<bool> UpdateAsync(UpdateCompanyDto dto); // <- debe coincidir
        Task<bool> DeleteAsync(Company company);       // <- debe coincidir
    }
}