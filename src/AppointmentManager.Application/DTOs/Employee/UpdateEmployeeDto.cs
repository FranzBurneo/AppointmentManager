namespace AppointmentManager.Application.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public Guid CompanyId { get; set; }
    }
}