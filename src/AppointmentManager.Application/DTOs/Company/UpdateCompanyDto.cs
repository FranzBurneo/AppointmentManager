namespace AppointmentManager.Application.DTOs.Company
{
    public class UpdateCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Website { get; set; }
        public bool IsActive { get; set; }
    }
}