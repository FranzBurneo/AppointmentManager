using AppointmentManager.Application.DTOs.EmployeeSchedule;
using AppointmentManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManager.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeScheduleController : ControllerBase
    {
        private readonly IEmployeeScheduleService _scheduleService;

        public EmployeeScheduleController(IEmployeeScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleService.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeScheduleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _scheduleService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeScheduleDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _scheduleService.UpdateAsync(dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _scheduleService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}