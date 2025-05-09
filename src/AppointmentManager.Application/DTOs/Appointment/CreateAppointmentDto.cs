namespace AppointmentManager.Application.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        public Guid ServiceId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public string? ClientEmail { get; set; }
    }
}