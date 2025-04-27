using AppointmentManager.Application.DTOs;
using AppointmentManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _companyService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var company = await _companyService.GetByIdAsync(id);
        return company is null ? NotFound() : Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CompanyDto dto) =>
        Ok(await _companyService.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CompanyDto dto)
    {
        if (id != dto.Id) return BadRequest("ID mismatch.");
        var result = await _companyService.UpdateAsync(dto);
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _companyService.DeleteAsync(id);
        return result ? Ok() : NotFound();
    }
}