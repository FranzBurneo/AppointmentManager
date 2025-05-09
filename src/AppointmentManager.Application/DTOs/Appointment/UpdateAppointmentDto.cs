namespace AppointmentManager.Application.DTOs.Appointment
{
    public class UpdateAppointmentDto : CreateAppointmentDto
    {
        public Guid Id { get; set; }
    }
}