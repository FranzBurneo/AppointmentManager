namespace AppointmentManager.Application.DTOs.EmployeeSchedule
{
    public class UpdateEmployeeScheduleDto : CreateEmployeeScheduleDto
    {
        public Guid Id { get; set; }
    }
}