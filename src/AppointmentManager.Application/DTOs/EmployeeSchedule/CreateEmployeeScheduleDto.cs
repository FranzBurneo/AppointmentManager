namespace AppointmentManager.Application.DTOs.EmployeeSchedule
{
    public class CreateEmployeeScheduleDto
    {
        public Guid EmployeeId { get; set; }
        public int DayOfWeek { get; set; } // 0 = Domingo, 1 = Lunes, ...
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}